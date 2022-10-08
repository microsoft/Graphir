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
            .AddTypeExtension<ScheduleQuery>()
            .AddType<ScheduleType>();
    }
}