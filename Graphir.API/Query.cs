using Graphir.API.Services;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using static Hl7.Fhir.Model.Bundle;
using System.Linq;

namespace Graphir.API
{
    public class Query
    {
        private readonly ITokenAcquisition _token;
        private readonly FhirClient _fhirService;
        private readonly FhirDataConnection _options;

        public Query(ITokenAcquisition token, FhirClient fhirService, IOptions<FhirDataConnection> options)
        {
            _token = token;
            _fhirService = fhirService;
            _options = options.Value;
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
            var token = await GetToken();
            return token;
        }

        public async Task<IList<Patient>> GetPatients()
        {
            var token = await GetToken();
            var bundle = await _fhirService.SearchAsync<Patient>(pageSize: 50);
            var result = new List<Patient>();
            while (bundle != null)
            {
                result.AddRange(bundle.Entry.Select(p => (Patient)p.Resource).ToList());
                bundle = await _fhirService.ContinueAsync(bundle);
            }
            return result;
        }

        private async Task<string> GetToken()
        {
            var tokenResult = await _token.GetAccessTokenForUserAsync(new[] { _options.Scopes });
            _fhirService.RequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResult);
            return tokenResult;
        }

    }    
}
