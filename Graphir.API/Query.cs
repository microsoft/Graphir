using Graphir.API.Services;
using Hl7.Fhir.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Graphir.API
{
    public class Query
    {
        private readonly ITokenAcquisition _token;
        private readonly FhirClient _fhirService;

        public Query(ITokenAcquisition token, FhirClient fhirService)
        {
            _token = token;
            _fhirService = fhirService;
        }

        public async Task<string> Meta()
        {
            var meta = await _fhirService.CapabilityStatementAsync();

            return JsonConvert.SerializeObject(meta);
        }

        public string GetMe(ClaimsPrincipal principal)
        {
            return principal.Identity.Name;
        }

        public async Task<string> GetFhirToken()
        {
            var tokenResult = await _token.GetAccessTokenForUserAsync(new[] { "https://chestist-fhir-api.azurehealthcareapis.com/user_impersonation" });
            return tokenResult;
        }
        
    }    
}
