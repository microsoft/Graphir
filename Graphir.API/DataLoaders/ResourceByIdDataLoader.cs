using Graphir.API.Services;
using GreenDonut;
using Hl7.Fhir.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Graphir.API.DataLoaders;

public class ResourceByIdDataLoader<T> : BatchDataLoader<string, T> where T : Resource
{
    private readonly FhirJsonClient _fhirService;

    public ResourceByIdDataLoader(
        IBatchScheduler scheduler,
        FhirJsonClient fhirService,
        DataLoaderOptions options)
        : base(scheduler, options)
    {
        _fhirService = fhirService;
    }

    protected override async Task<IReadOnlyDictionary<string, T>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        var searchStr = string.Join(",", keys.Select(k => k));
        var results = await _fhirService.SearchAsync<T>(new[] { $"_id={searchStr}" });
        return results.ToDictionary(p => p.Id);
    }
      
}