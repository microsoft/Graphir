using Graphir.API.Services;

using Hl7.Fhir.Model;

using HotChocolate;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Graphir.API.DataLoaders;

public class AppointmentResolvers
{
    public async Task<List<Appointment>> GetAppointmentListResources(
        [Service] FhirJsonClient client,
        [Argument("patient")] string? patientId,
        [Argument("practitioner")] string? practitionerId,
        [Argument("date")] DateTime? date)
    {
        var criteria = new List<string>();

        if (!string.IsNullOrEmpty(patientId))
            criteria.Add($"patient={patientId}");
        if (!string.IsNullOrEmpty(practitionerId))
            criteria.Add($"practitioner={practitionerId}");
        if (date is not null)
            criteria.Add($"date={date:yyyy-MM-dd}");

        return await client.SearchAsync<Appointment>(criteria);
    }
}