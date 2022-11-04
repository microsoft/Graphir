﻿using Graphir.API.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Graphir.API;

public class Query
{
    private readonly FhirJsonClient _fhirService;

    public Query(FhirJsonClient fhirService) => _fhirService = fhirService;

    public async Task<string> Meta() => await _fhirService.CapabilityStatementAsync();

    public string? GetMe(ClaimsPrincipal principal) => principal.Identity?.Name;
}