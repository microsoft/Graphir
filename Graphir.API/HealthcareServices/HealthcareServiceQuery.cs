using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.HealthcareServices;

[ExtendObjectType(OperationTypeNames.Query)]
public class HealthcareServiceQuery
{
    private readonly FhirClient _client;

    public HealthcareServiceQuery(FhirClient client)
    {
        _client = client;
    }
    
    [GraphQLName("HealthcareServiceById")]
    public async Task<HealthcareService> GetHealthCareService(string id)
    {
        var bundle = await _client.SearchByIdAsync<HealthcareService>(id);
        return (HealthcareService)bundle.Entry.First().Resource;
    }
    
    [GraphQLName("HealthcareServices")]
    public async Task<IEnumerable<HealthcareService>> GetHealthCareServices()
    {
        var bundle = await _client.SearchAsync<HealthcareService>(new string[] { });
        return bundle.Entry.Select(x => (HealthcareService)x.Resource).ToList();
    }

    [GraphQLName("HealthcareServiceByName")]
    public async Task<IEnumerable<HealthcareService>> GetHealthCareServiceByName(string name)
    {
        var bundle = await _client.SearchAsync<HealthcareService>(new[] { $"name={name}" });
        return bundle.Entry.Select(x => (HealthcareService)x.Resource).ToList();
    }
}