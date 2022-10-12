using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slot = Hl7.Fhir.Model.Slot;

namespace Graphir.API.Extensions;

internal static class SlotStartup
{
    public static IRequestExecutorBuilder AddSlots
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<ResourceQuery<Slot, SlotType>>()
            .AddDataLoader<ResourceByIdDataLoader<Slot>>()
            .AddType<SlotType>();
    }
}