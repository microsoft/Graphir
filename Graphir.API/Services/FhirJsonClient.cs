using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
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
        var reqStr = $"{_httpClient.BaseAddress}/metadata";
        return await _httpClient.GetStringAsync(reqStr);
    }

    public async Task<List<T>> SearchAsync<T>(string query) where T : Resource
    {
        var reqStr = $"{_httpClient.BaseAddress}/{typeof(T).Name}?{query}";
        var json = await _httpClient.GetStringAsync(reqStr);
        var bundle = await _parser.ParseAsync<Bundle>(json);
        var result = bundle.Entry.Select(p => (T)p.Resource).ToList();
        return result;
    }

    public async Task<List<T>> SearchAsync<T>(IList<string> criteria) where T : Resource
    {
        return await SearchAsync<T>(string.Join('&', criteria.ToArray()));
    }
    
}
