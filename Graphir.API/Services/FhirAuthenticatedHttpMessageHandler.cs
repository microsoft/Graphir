﻿namespace Graphir.API.Services;

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
        string token = await _tokenService.GetAccessTokenForAppAsync(_fhirOptions.Scopes);
        
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}