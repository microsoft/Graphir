using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Graphir.API.Services
{
    public class FhirHttpMessageHandler : DelegatingHandler
    {
        private readonly FhirDataConnection _settings;

        public FhirHttpMessageHandler(IOptions<FhirDataConnection> options)
        {
            _settings = options.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.RequestUri = string.IsNullOrEmpty(request.RequestUri?.Query)
                ? new System.Uri($"{request.RequestUri?.AbsoluteUri}?_count={_settings.ResultsLimit}")
                : new System.Uri($"{request.RequestUri?.AbsoluteUri}&_count={_settings.ResultsLimit}");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}