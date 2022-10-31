using Graphir.API.Services;
using Hl7.Fhir.ElementModel.Types;
using Hl7.Fhir.Model;
using HotChocolate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Graphir.API.DataLoaders;

public class PatientResolvers
{
    public async Task<List<Patient>> GetPatientListResources(
        [Service] FhirJsonClient client,
        [Argument("family")] string? family,
        [Argument("given")] string? given,        
        [Argument("birthdate")] DateTime? birthDate,
        [Argument("general_practitioner")] string? generalPractitioner)
    {
        var criteria = new List<string>();

        if (!string.IsNullOrEmpty(family))
            criteria.Add($"family={family}");
        if (!string.IsNullOrEmpty(given))
            criteria.Add($"given={given}");
        if (birthDate is not null)
            criteria.Add($"birthdate={birthDate:yyyy-MM-dd}");
        if (!string.IsNullOrEmpty(generalPractitioner))
            criteria.Add($"general-practitioner={generalPractitioner}");

        var result = await client.SearchAsync<Patient>(criteria);
        return result;
    }
}
