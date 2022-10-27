using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graphir.API.DataLoaders;

public class AppointmentResolvers
{
    public async Task<List<Appointment>> GetAppointmentListResources([Service] FhirClient client,
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

        var bundle = await client.SearchAsync(nameof(Appointment), criteria.ToArray());
        var results = bundle.Entry.Select(x => (Appointment)x.Resource).ToList();
        return results;
    }
}
