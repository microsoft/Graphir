using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using Graphir.API.Queries;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class ConditionStartup
{
    public static IRequestExecutorBuilder AddCondition(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Condition>>()
            .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Condition, ConditionType>>()
            .AddType<ConditionType>();
    }
}