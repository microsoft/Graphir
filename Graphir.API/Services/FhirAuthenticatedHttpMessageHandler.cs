using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Graphir.API.Services;

public class FhirAuthenticatedHttpMessageHandler : DelegatingHandler
{
    private readonly ITokenAcquisition _tokenService;
    private readonly FhirDataConnection _fhirOptions;

    public FhirAuthenticatedHttpMessageHandler(ITokenAcquisition tokenService, IOptions<FhirDataConnection> options)
    {
        _tokenService = tokenService;
        _fhirOptions = options.Value;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Add auth token to request Headers
        var token = await _tokenService.GetAccessTokenForUserAsync(new[] { _fhirOptions.Scopes });
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Append max result size to querystring
        request.RequestUri = new System.Uri($"{request.RequestUri?.AbsoluteUri}&_count={_fhirOptions.ResultsLimit}");
        return await base.SendAsync(request, cancellationToken);
    }
}