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

    public FhirAuthenticatedHttpMessageHandler(ITokenAcquisition tokenService, FhirDataConnection options)
    {
        _tokenService = tokenService;
        _fhirOptions = options;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
       var token = await _tokenService.GetAccessTokenForUserAsync(new[] { _fhirOptions.Scopes });

       request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}