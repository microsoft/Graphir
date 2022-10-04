using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.Slots;

[ExtendObjectType(OperationTypeNames.Query)]
public class SlotQuery
{
    private readonly FhirClient _client;

    public SlotQuery(FhirClient client)
    {
        _client = client;
    }
    
    [GraphQLName("Slots")]
    public async Task<IEnumerable<Slot>> GetSlots()
    {
        var bundle = await _client.SearchAsync<Slot>();
        return bundle.Entry.Select(e => (Slot)e.Resource).ToList();
    }
    
    [GraphQLName("SlotById")]
    public async Task<Slot> GetSlotById(string id)
    {
        var bundle = await _client.SearchByIdAsync<Slot>(id);
        return (Slot)bundle.Entry.First().Resource;
    }
    
    [GraphQLName("SlotsByStatus")]
    public async Task<IEnumerable<Slot>> GetSlotsByStatus(string status)
    {
        var bundle = await _client.SearchAsync<Slot>(new[] { $"status={status}" });
        return bundle.Entry.Select(e => (Slot)e.Resource).ToList();
    }
}