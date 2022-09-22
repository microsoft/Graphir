using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class LocationStartup 
{
    public static IRequestExecutorBuilder AddLocation
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddType<LocationType>()
            .AddType<LocationPositionType>();
    }
}