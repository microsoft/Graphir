using Graphir.API.Schema;
using Graphir.API.Slots;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class SlotStartup
{
    public static IRequestExecutorBuilder AddSlots
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<SlotDataLoaders>()
            .AddType<SlotType>();
    }
}