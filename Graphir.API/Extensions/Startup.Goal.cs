using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using Hl7.Fhir.Model;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

public static class GoalStartup
{
    public static IRequestExecutorBuilder AddGoal(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Goal>>()
            .AddTypeExtension<ResourceQuery<Goal, GoalType>>()
            .AddType<GoalType>();
    }
}
