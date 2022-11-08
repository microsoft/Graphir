using Graphir.API.Services;

using Hl7.Fhir.Model;

using HotChocolate;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Graphir.API.DataLoaders;

public class PractitionerResolvers
{
    public async Task<List<Practitioner>> GetPractitionerListResources(
        [Service] FhirJsonClient client,
        [Argument("family")] string? family,
        [Argument("given")] string? given,
        [Argument("email")] string? email)
    {
        var criteria = new List<string>();

        if (!string.IsNullOrEmpty(family))
            criteria.Add($"family={family}");
        if (!string.IsNullOrEmpty(given))
            criteria.Add($"given={given}");
        if (!string.IsNullOrEmpty(email))
            criteria.Add($"email={email}");

        return await client.SearchAsync<Practitioner>(criteria);
    }
}