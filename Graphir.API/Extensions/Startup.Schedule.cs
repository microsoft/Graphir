using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class StartupSchedule
{
    public static IRequestExecutorBuilder AddSchedule(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Schedule>>()
            .AddTypeExtension<ScheduleQuery>()
            .AddType<ScheduleType>();
    }
}