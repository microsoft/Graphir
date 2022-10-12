using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HealthcareService = Hl7.Fhir.Model.HealthcareService;

namespace Graphir.API.Extensions;

internal static class HealthcareServiceStartup
{
    public static IRequestExecutorBuilder AddHealthcareService
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<HealthcareService>>()
            .AddTypeExtension<ResourceQuery<HealthcareService, HealthcareServiceType>>()
            .AddType<HealthcareServiceType>();
    }
}