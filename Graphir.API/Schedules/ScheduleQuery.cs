using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.Schedules;

[ExtendObjectType(OperationTypeNames.Query)]
public class ScheduleQuery
{
    private readonly FhirClient _client;

    public ScheduleQuery(FhirClient client)
    {
        _client = client;
    }
    
    //Get all schedules
    [GraphQLName("Schedules")]
    public async Task<List<Schedule>> GetSchedules()
    {
        var bundle = await _client.SearchAsync<Schedule>(new string[] { });
        var schedules =  bundle.Entry.Select(e => (Schedule)e.Resource).ToList();
        return schedules;
    }
    
    //Get schedule by id
    [GraphQLName("ScheduleById")]
    public async Task<Schedule> GetScheduleById(string id)
    {
        var bundle = await _client.SearchByIdAsync<Schedule>(id);
        var schedule = bundle.Entry.Select(e => (Schedule)e.Resource).FirstOrDefault();
        return schedule!;
    }
}