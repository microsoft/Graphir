using Graphir.API.Services;
using Hl7.Fhir.Model;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Graphir.API.DataLoaders;

public class RelatedPersonResolvers
{
    public async Task<List<RelatedPerson>> GetRelatedPersonResources(
        [Service] FhirJsonClient client,
        [Argument("family")] string? lastName,
        [Argument("given")] string? firstName,
        [Argument("birthdate")] DateTime? birthDate)
    {
        var criteria = new List<string>();

        if (!string.IsNullOrEmpty(lastName))
            criteria.Add($"family={lastName}");
        if (!string.IsNullOrEmpty(firstName))
            criteria.Add($"given={firstName}");
        if (birthDate is not null)
            criteria.Add($"birthdate={birthDate:yyyy-MM-dd}");

        var result = await client.SearchAsync<RelatedPerson>(criteria);
        return result;
    }
}
