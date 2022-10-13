using GreenDonut;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Graphir.API.DataLoaders;

public class ResourceByIdDataLoader<T> : BatchDataLoader<string, T> where T : Resource
{
    private readonly FhirClient _fhirService;

    public ResourceByIdDataLoader(
        IBatchScheduler scheduler,
        FhirClient fhirService,
        DataLoaderOptions options)
        : base(scheduler, options)
    {
        _fhirService = fhirService;
    }

    protected override async Task<IReadOnlyDictionary<string, T>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        var results = new List<T>();
        var searchStr = string.Join(",", keys.Select(k => k));
        var response = await _fhirService.SearchAsync(typeof(T).Name, new[] { $"_id={searchStr}" });
        if (response is not null)
        {
            results = response.Entry.Select(p => (T)p.Resource).ToList();
        }

        return results.ToDictionary(p => p.Id);
    }
      
}