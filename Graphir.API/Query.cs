namespace Graphir.API
{
    public class Query
    {
        private readonly FhirClient _fhirService;

        public Query(FhirClient fhirService)
        {
            _fhirService = fhirService;
        }

        public async Task<string> Meta()
        {
            return JsonConvert.SerializeObject(await _fhirService.CapabilityStatementAsync());
        }

        public string? GetMe(ClaimsPrincipal principal)
        {
            return principal.Identity?.Name;
        }
    }
}