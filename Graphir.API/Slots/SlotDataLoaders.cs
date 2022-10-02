using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GreenDonut;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Graphir.API.Slots;

public class SlotDataLoaders : BatchDataLoader<string, Schedule>
{
    private readonly FhirClient _client;

    public SlotDataLoaders(
        IBatchScheduler batchScheduler,
        FhirClient client,
        DataLoaderOptions? options) 
        : base(batchScheduler, options)
    {
        _client = client;
    }

    protected override async Task<IReadOnlyDictionary<string, Schedule>>
        LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        var results = new List<Schedule>();
        foreach (var key in keys)
        {
            var response = await _client.SearchByIdAsync<Schedule>(key);
            if(response is not null)
                results = response.Entry.Select(x => x.Resource as Schedule).ToList()!;
        }
        return results.ToDictionary(s => s.Id);
    }
}