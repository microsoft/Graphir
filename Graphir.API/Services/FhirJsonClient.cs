using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using HotChocolate.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Graphir.API.Services;

public class FhirJsonClient
{
    private readonly HttpClient _httpClient;
    private readonly FhirJsonParser _parser;

    public FhirJsonClient(HttpClient client, FhirJsonParser parser)
    {
        _httpClient = client;
        _parser = parser;
    }

    public async Task<string> CapabilityStatementAsync()
    {
        var reqUri = new UriBuilder(_httpClient.BaseAddress!.ToString());
        reqUri.Path = "metadata";
        return await _httpClient.GetStringAsync(reqUri.Uri);
    }

    public async Task<List<T>> SearchAsync<T>(string query) where T : Resource
    {
        try
        {
            var reqUri = new UriBuilder(_httpClient.BaseAddress!.ToString());
            reqUri.Path += reqUri.Path.EndsWith('/') ? typeof(T).Name : $"/{typeof(T).Name}";
            if (!string.IsNullOrEmpty(query))
                reqUri.Query += $"{query}";

            var json = await _httpClient.GetStringAsync(reqUri.Uri.ToString());
            var bundle = await _parser.ParseAsync<Bundle>(json);
            var result = bundle.Entry.Select(p => (T)p.Resource).ToList();
            return result;
        }
        catch (Exception ex)
        {
            // throw a QueryException message so GraphQL displays errors
            throw new QueryException(ex.Message);
        }
    }

    public async Task<List<T>> SearchAsync<T>(IList<string> criteria) where T : Resource
    {
        return await SearchAsync<T>(string.Join('&', criteria.ToArray()));
    }
    
}
