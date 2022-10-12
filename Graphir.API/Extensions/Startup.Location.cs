using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Location = Hl7.Fhir.Model.Location;

namespace Graphir.API.Extensions;

internal static class LocationStartup 
{
    public static IRequestExecutorBuilder AddLocation
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<ResourceQuery<Location, LocationType>>()
            .AddDataLoader<ResourceByIdDataLoader<Location>>()
            .AddType<LocationType>();
    }
}