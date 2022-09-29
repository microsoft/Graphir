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
            .AddType<HealthcareServiceNotAvailableType>()
            .AddType<HealthcareServiceAvailableTimeType>()
            .AddType<EligibilityComponentType>()
            .AddType<ContainedResourceType>()
            .AddType<MarkDownType>()
            .AddType<HealthcareServiceType>();
    }
}