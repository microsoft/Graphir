using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GreenDonut;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Graphir.API.MedicationAdministrations;

public class MedicationSubjectDataLoader : BatchDataLoader<string, Patient>
{
    private readonly FhirClient _client;
    public MedicationSubjectDataLoader(
        IBatchScheduler batchScheduler, 
        FhirClient client, 
        DataLoaderOptions? options = null) : 
        base(batchScheduler, options)
    {
        _client = client;
    }

    protected override async Task<IReadOnlyDictionary<string, Patient>> 
        LoadBatchAsync(IReadOnlyList<string> keys, 
            CancellationToken cancellationToken)
    {
        var result = new List<Patient>();
        var searchStr = string.Join(",", keys.Select(k=>k));
        var bundle = await _client.SearchAsync<Patient>(new [] { $"_id={searchStr}" });
        if(bundle is not null)
        {
            result = bundle.Entry.Select(e => e.Resource as Patient).ToList()!;
        }
        
        return result.ToDictionary(x => x.Id);
    }
}