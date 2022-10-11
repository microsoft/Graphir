using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class PractitionerRoleStartup
{
    public static IRequestExecutorBuilder AddPractitionerRole(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.PractitionerRole>>()
            .AddTypeExtension<PractitionerRoleQuery>()
            .AddType<PractitionerRoleType>();
    }
}