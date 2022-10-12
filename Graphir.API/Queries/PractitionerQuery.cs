using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graphir.API.Queries;

[ExtendObjectType(OperationTypeNames.Query)]


public class PractitionerQuery
{
    private readonly FhirClient _fhirService;

    public PractitionerQuery(FhirClient fhirService)
    {
        _fhirService = fhirService;
    }

    /// <summary>
    /// Get Practitioner by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <example>
    /// query practitioner{ 
    ///     Practitioner(id: "00000174-0823-dc8d-0000-00000000e876")
    ///     {
    ///         id
    ///         name{ given family}
    ///         qualification{
    ///             code{ text}
    ///             period{ start end}
    ///             issuer
    ///         }
    ///     }
    /// }
    /// 
    /// </example>
    [GraphQLName("Practitioner")]
    public async Task<Practitioner> GetPractitioner(string id, ResourceByIdDataLoader<Practitioner> dataLoader) => await dataLoader.LoadAsync(id);

    /// <summary>
    /// Get List of Practitioners
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <example>
    ///   query practitionerList{ 
    ///      PractitionerList{              //Optional w/ Name:    PractitionerList(name: "Kutch"){  
    ///         id
    ///         name
    ///             { given family }
    ///         qualification{
    ///             code{text}
    ///             period{start end}
    ///             issuer
    ///         }
    ///      }
    ///   }        
    /// </example>
    [GraphQLName("PractitionerList")]
    public async Task<IList<Practitioner>> GetPractitionerList(string name = "")
    {
        return string.IsNullOrWhiteSpace(name)
            ? await GetPractitionersAsync()
            : await SearchPractitionerByName(name);
    }

    /// <summary>
    /// Get paged list of Practitioners using GraphQL Connection
    /// This will not be optimized for MVP since we are proxying through Firely to FHIR API.
    /// </summary>
    /// <param name="after">Only fetch items after this cursor (Practitioner.Id)</param>
    /// <param name="first">Number of items to fetch</param>
    /// <returns></returns>
    [UsePaging]
    [GraphQLName("PractitionerConnection")]
    public async Task<Connection<Practitioner>> GetPractitionerConnection(string? after, int? first)
    {
        // TODO: get list of Practitioners based on params
        var allPractitioners = await GetPractitionersAsync();
        var totalCount = allPractitioners.Count();
        int pageSize = first ?? 10;

        if (!string.IsNullOrEmpty(after))
        {
            allPractitioners = allPractitioners.SkipWhile(p => !p.Id.Equals(after, System.StringComparison.InvariantCultureIgnoreCase)).Skip(1).ToList();
        }

        var edges = allPractitioners.Select(practitioner => new Edge<Practitioner>(practitioner, practitioner.Id)).Take(pageSize).ToList();
        bool hasNext = allPractitioners.Count() > pageSize;
        bool hasPrevious = !string.IsNullOrEmpty(after);
        string firstCursor = edges.FirstOrDefault()?.Node.Id;
        string lastCursor = edges.LastOrDefault()?.Node.Id;
        var pageInfo = new ConnectionPageInfo(hasNext, hasPrevious, firstCursor, lastCursor);
        var connection = new Connection<Practitioner>(edges, pageInfo, ct => ValueTask.FromResult(0));

        return connection;
    }

    private async Task<List<Practitioner>> SearchPractitionerByName(string name)
    {
        var searchResults = new List<Practitioner>();
        var filterString = $"name:contains={name}";
        Bundle bundle = await _fhirService.SearchAsync<Practitioner>(criteria: new[] { filterString });
        if (bundle != null)
            searchResults = bundle.Entry.Select(p => (Practitioner)p.Resource).ToList();
        return searchResults;
    }

    private async Task<List<Practitioner>> GetPractitionersAsync()
    {
        var bundle = await _fhirService.SearchAsync<Practitioner>(pageSize: 50);
        var result = new List<Practitioner>();
        while (bundle != null)
        {
            result.AddRange(bundle.Entry.Select(p => (Practitioner)p.Resource).ToList());
            bundle = await _fhirService.ContinueAsync(bundle);
        }
        return result;
    }

}