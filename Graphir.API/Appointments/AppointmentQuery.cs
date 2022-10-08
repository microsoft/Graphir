using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    public async Task<Appointment> GetAppointmentById(string id, ResourceByIdDataLoader<Hl7.Fhir.Model.Appointment> loader) => await loader.LoadAsync(id);    

    /// <summary>
    /// Get a list of Appointment resources
    /// </summary>
    /// <example>
    /// query AppointmentId {
    ///    AppointmentById(id: "30239")
    ///    {
    ///        id
    ///        status
    ///      start
    ///    end
    ///      minutesDuration
    ///    participant {
    ///            status
    ///            actor {
    ///                display
    ///                reference {
    ///                    ... on Patient {
    ///                        id
    ///                        birthDate
    ///                    }
    ///                }
    ///            }
    ///
    ///        }
    ///    }
    /// }
    /// </example>
    /// <returns></returns>
    [GraphQLName("AppointmentList")]
    public async Task<List<Appointment>> GetAppointments()
    {
        var bundle = await _client.SearchAsync<Appointment>();
        return bundle.Entry.Select(e=>(Appointment) e.Resource).ToList();
    }
}