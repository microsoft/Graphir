using Hl7.Fhir.Rest;
using System.Security.Claims;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace Graphir.API;

public class Query
{
    private readonly FhirClient _fhirService;

    public Query(FhirClient fhirService) => _fhirService = fhirService;

    public async Task<string> Meta() => SerializeObject(await _fhirService.CapabilityStatementAsync());

    public string? GetMe(ClaimsPrincipal principal) => principal.Identity?.Name;
}