using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PractitionerRole = Hl7.Fhir.Model.PractitionerRole;

namespace Graphir.API.Extensions;

internal static class PractitionerRoleStartup
{
    public static IRequestExecutorBuilder AddPractitionerRole(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<PractitionerRole>>()
            .AddTypeExtension<ResourceQuery<PractitionerRole, PractitionerRoleType>>()
            .AddType<PractitionerRoleType>();
    }
}