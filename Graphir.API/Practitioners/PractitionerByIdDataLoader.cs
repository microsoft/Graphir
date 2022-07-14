namespace Graphir.API.Practitioners
{
    public class PractitionerByIdDataLoader : BatchDataLoader<string, Practitioner>
    {
        private readonly FhirClient _fhirService;

        public PractitionerByIdDataLoader(
            IBatchScheduler scheduler,
            FhirClient fhirService,
            DataLoaderOptions options)
            : base(scheduler, options)
        {
            _fhirService = fhirService;
        }        

        protected override async Task<IReadOnlyDictionary<string, Practitioner>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            var results = new List<Practitioner>();
            var searchStr = string.Join(",", keys.Select(k => k));
            var response = await _fhirService.SearchAsync<Practitioner>(new[] { $"_id={searchStr}" });
            if (response is not null)
            {
                results = response.Entry.Select(p => (Practitioner)p.Resource).ToList();
            }            

            return results.ToDictionary(p => p.Id);
        }
    }
}
