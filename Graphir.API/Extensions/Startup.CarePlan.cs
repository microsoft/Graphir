using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;

using Hl7.Fhir.Model;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class CarePlanStartup
{
    public static IRequestExecutorBuilder AddCarePlan(this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<CarePlan>>()
            .AddTypeExtension<ResourceQuery<CarePlan, CarePlanType>>()
            .AddType<CarePlanType>();
    }
}