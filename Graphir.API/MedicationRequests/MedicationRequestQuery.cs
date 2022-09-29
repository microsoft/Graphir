using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.MedicationRequests;

[ExtendObjectType("Query")]
public class MedicationRequestQuery
{
    private readonly FhirClient _client;

    public MedicationRequestQuery(FhirClient client)
    {
        _client = client;
    }
    
    //Get all MedicationRequests as a list
    [GraphQLName("MedicationRequests")]
    public async Task<List<MedicationRequest>> GetMedicationRequests()
    {
        var bundle = await _client.SearchAsync<MedicationRequest>(new string[] { });
        return bundle.Entry.Select(x => (MedicationRequest)x.Resource).ToList();
    }
    
    //Get a MedicationRequest by id
    [GraphQLName("MedicationRequestById")]
    public async Task<MedicationRequest> GetMedicationRequestById(string id)
    {
        var bundle = await _client.SearchByIdAsync<MedicationRequest>(id);
        return bundle.Entry.Select(x =>(MedicationRequest) x.Resource).FirstOrDefault()!;
    }
    
}