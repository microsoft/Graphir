using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.Medications;

[ExtendObjectType(OperationTypeNames.Query)]
public class MedicationQuery 
{
    private readonly FhirClient _client;

    public MedicationQuery(FhirClient client)
    {
        _client = client;
    }
    
    //Get list of medications  
    [GraphQLName("Medications")]
    public async Task<List<Medication>> GetMedications()
    {
        var bundle =  await _client.SearchAsync<Medication>();
        return bundle.Entry.Select(e => (Medication)e.Resource).ToList();
    }
    
    //Get a medication detail by id
    [GraphQLName("MedicationById")]
    public async Task<Medication> GetMedicationById(string id)
    {
        var bundle = await _client.SearchByIdAsync<Medication>(id);
        return bundle.Entry.Select(e => (Medication)e.Resource).FirstOrDefault()!;
    }
    
    //Filter medication list by name
    [GraphQLName("MedicationByName")]
    public async Task<List<Medication>> GetMedicationByName(string name)
    {
        var bundle = await _client.SearchAsync<Medication>();
        var medicationList = bundle.Entry.Select(e => (Medication)e.Resource).ToList();
        var filteredMedicationListByName = medicationList.Where(m => m.Text.Div.Contains(name)).ToList();
        return filteredMedicationListByName;
    }
    
    //Filter medication list by code
    [GraphQLName("MedicationByCode")]
    public async Task<List<Medication>> GetMedicationByCode(string code)
    {
        var bundle = await _client.SearchAsync<Medication>(new[] { $"code={code}" });
        var filteredMedicationListByCode = bundle.Entry.Select(e => (Medication)e.Resource).ToList();
        return filteredMedicationListByCode;
    }
    
}