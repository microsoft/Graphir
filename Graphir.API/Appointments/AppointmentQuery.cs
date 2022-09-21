using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.Appointments;

[ExtendObjectType(OperationTypeNames.Query)]
public class AppointmentQuery
{
    private readonly FhirClient _client;

    public AppointmentQuery(FhirClient client)
    {
        _client = client;
    }
    
    [GraphQLName("AppointmentById")]
    public async Task<Appointment> GetAppointment(string id)
    {
        var bundle = await _client.SearchByIdAsync<Appointment>(id);
        return bundle.Entry.Select(e=>(Appointment) e.Resource).FirstOrDefault()!;
    }
    
    [GraphQLName("AppointmentList")]
    public async Task<List<Appointment>> GetAppointments()
    {
        var bundle = await _client.SearchAsync<Appointment>();
        return bundle.Entry.Select(e=>(Appointment) e.Resource).ToList();
    }
}