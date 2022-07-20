namespace Graphir.API.Practitioners;

public class PatientByIdDataLoader : BatchDataLoader<string, Patient>
{
    private readonly FhirClient _fhirService;

    public PatientByIdDataLoader( IBatchScheduler scheduler,  
        FhirClient fhirService, DataLoaderOptions options) : base(scheduler, options)
    {
        _fhirService = fhirService;
    }

    protected override async Task<IReadOnlyDictionary<string, Patient>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        var results = new List<Patient>();
        string? searchStr = string.Join(",", keys.Select(k => k));
        if (await _fhirService.SearchAsync<Patient>(new[] { $"_id={searchStr}" }) is { } response)
        {
            results = response.Entry.Select(p => (Patient)p.Resource).ToList();
        }

        return results.ToDictionary(p => p.Id);
    }
}