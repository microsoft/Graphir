using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

using Schedule = Hl7.Fhir.Model.Schedule;

namespace Graphir.API.Extensions;

internal static class StartupSchedule
{
    public static IRequestExecutorBuilder AddSchedule(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Schedule>>()
            .AddTypeExtension<ResourceQuery<Schedule, ScheduleType>>()
            .AddType<ScheduleType>();
    }
}