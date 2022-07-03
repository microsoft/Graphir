using Hl7.Fhir.Rest;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

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
            var meta = await _fhirService.CapabilityStatementAsync();

            return JsonConvert.SerializeObject(meta);
        }

        public string? GetMe(ClaimsPrincipal principal)
        {
            return principal.Identity?.Name;
        }               

    }    
}
