using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphir.API.DataLoaders;
using Hl7.Fhir.Rest;

using HotChocolate;
using HotChocolate.Types;

using Location = Hl7.Fhir.Model.Location;

namespace Graphir.API.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class LocationQuery
{
    private readonly FhirClient _client;

    public LocationQuery(FhirClient client)
    {
        _client = client;
    }

    [GraphQLName("Locations")]
    public async Task<List<Location>> GetLocations()
    {
        var bundle = await _client.SearchAsync<Location>();
        var locationList = bundle.Entry.Select(x => (Location)x.Resource).ToList();
        return locationList;
    }

    [GraphQLName("LocationById")]
    public async Task<Location> GetLocationById(string id, ResourceByIdDataLoader<Location> loader) => await loader.LoadAsync(id);

    [GraphQLName("LocationByName")]
    public async Task<List<Location>> GetLocationByName(string name)
    {
        var bundle = await _client.SearchAsync<Location>(new[] { $"name={name}" });
        var location = bundle.Entry.Select(x => (Location)x.Resource).ToList();
        return location!;
    }
}