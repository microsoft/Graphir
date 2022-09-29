using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GreenDonut;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Graphir.API.MedicationAdministrations;

public class PerformerComponentPractitionerDataLoader : BatchDataLoader<string, Practitioner>
{
    private readonly FhirClient _client;
    public PerformerComponentPractitionerDataLoader(
        IBatchScheduler batchScheduler, 
        FhirClient client, 
        DataLoaderOptions? options = null) 
        : base(batchScheduler, options)
    {
        _client = client;
    }

    protected override async Task<IReadOnlyDictionary<string, Practitioner>> 
        LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        var results = new List<Practitioner>();
        var searchStr = string.Join(",", keys.Select(k => k));
        var response = await _client.SearchAsync<Practitioner>(new[] { $"_id={searchStr}" });
        if (response is not null)
        {
            results = response.Entry.Select(p => (Practitioner)p.Resource).ToList();
        }            

        return results.ToDictionary(p => p.Id);
    }
}