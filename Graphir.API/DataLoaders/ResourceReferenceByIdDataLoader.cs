using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GreenDonut;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Graphir.API.Patients;

/// <summary>
/// string key must include relative path to referenced resource
/// '/Patient/1234'
/// '/Device/345'
/// </summary>
public class ResourceReferenceByIdDataLoader : BatchDataLoader<string, Resource>
{
    private readonly FhirClient _fhirService;

    public ResourceReferenceByIdDataLoader(
        IBatchScheduler scheduler,
        FhirClient fhirService,
        DataLoaderOptions options)
        : base(scheduler, options)
    {
        _fhirService = fhirService;
    }

    protected override async Task<IReadOnlyDictionary<string, Resource>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        var results = new List<Resource>();
        //var searchStr = string.Join(",", keys.Select(k => k));
        var response = await _fhirService.GetAsync(keys[0]);
        //var response = await _fhirService.SearchAsync<Patient>(new[] { $"_id={searchStr}" });
        if (response is not null)
        {
            results.Add((Patient)response);
        }

        return results.ToDictionary(p => p.Id);
    }
    
}