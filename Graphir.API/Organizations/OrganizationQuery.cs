using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.Organizations;

[ExtendObjectType(OperationTypeNames.Query)]
public class OrganizationQuery
{
    private readonly FhirClient _fhirClient;

    public OrganizationQuery(FhirClient fhirClient)
    {
        _fhirClient = fhirClient;
    }
    
    
    [GraphQLName("OrganizationList")]
    public async Task<IList<Organization>> GetOrganizationList()
    {
        var bundle = await _fhirClient.SearchAsync<Organization>(pageSize: 50);
        var result = bundle.Entry.Select(entry => (entry.Resource as Organization)!).ToList();
        return result.ToList();
    }
    
    [GraphQLName("OrganizationByName")]
    public async Task<IList<Organization>> GetOrganizationListByNameAsync(string name)
    {
        var searchParams = new SearchParams().Where($"name={name}");
        var searchResults = await _fhirClient.SearchAsync<Organization>(searchParams);
        var organizations = searchResults.Entry.Select(e => (Organization)e.Resource).ToList();
        return organizations;
    }
    
}