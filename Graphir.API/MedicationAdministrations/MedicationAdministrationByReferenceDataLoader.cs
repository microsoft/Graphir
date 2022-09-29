using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GreenDonut;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Graphir.API.MedicationAdministrations;

public class MedicationAdministrationByReferenceDataLoader : BatchDataLoader<string, Medication>
{
    private readonly FhirClient _client;

    public MedicationAdministrationByReferenceDataLoader
    (IBatchScheduler batchScheduler,
        FhirClient client,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _client = client;
    }

    protected override async Task<IReadOnlyDictionary<string, Medication>>
        LoadBatchAsync(IReadOnlyList<string> keys,
            CancellationToken cancellationToken)
    {
        var results = new List<Medication>();
        var searchStrings = string.Join(",", keys);
        var searchParams = new SearchParams()
            .Where($"_id={searchStrings}");

        var bundle = await _client.SearchAsync<Medication>(searchParams);
        results.AddRange(bundle.Entry.Select(x => x.Resource as Medication)!);
        return results.ToDictionary(x => x.Id);
    }
}