using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class HealthcareServiceStartup
{
    public static IRequestExecutorBuilder AddHealthcareService
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.HealthcareService>>()
            .AddTypeExtension<HealthcareServiceQuery>()
            .AddType<HealthcareServiceNotAvailableType>()
            .AddType<HealthcareServiceAvailableTimeType>()
            .AddType<EligibilityComponentType>()
            .AddType<MarkDownType>()
            .AddType<HealthcareServiceType>();
    }
}