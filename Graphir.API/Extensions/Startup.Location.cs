using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using Hl7.Fhir.Model;
using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class LocationStartup 
{
    public static IRequestExecutorBuilder AddLocation
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Location>>()
            .AddType<LocationType>()
            .AddType<LocationPositionType>();
    }
}