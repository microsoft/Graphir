﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.MedicationAdministrations;

[ExtendObjectType(OperationTypeNames.Query)]
public class MedicationAdministrationQuery
{
    private readonly FhirClient _client;

    public MedicationAdministrationQuery(FhirClient client)
    {
        _client = client;
    }
    
    //Get all list of MedicationAdministration
    [GraphQLName("MedicationAdministrations")]
    public async Task<IEnumerable<MedicationAdministration>> GetMedicationAdministrations()
    {
        var result = await _client.SearchAsync<MedicationAdministration>(new string[] { });
        return result.Entry.Select(e => (MedicationAdministration) e.Resource);
    }
    
    //Get MedicationAdministration by Id
    [GraphQLName("MedicationAdministrationById")]
    public async Task<MedicationAdministration> GetMedicationAdministrationById(string id)
    {
        var bundle = await _client.SearchByIdAsync<MedicationAdministration>(id);
        return (MedicationAdministration) bundle.Entry.First().Resource;
    }
    
}