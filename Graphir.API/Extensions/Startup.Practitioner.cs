using Graphir.API.DataLoaders;
using Graphir.API.Mutations;
using Graphir.API.Queries;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class PractitionerStartup
{
    public static IRequestExecutorBuilder AddPractitioner(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder.AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Practitioner>>()
            .AddTypeExtension<PractitionerMutation>()
            .AddTypeExtension<PractitionerQuery>()
            .AddType<PractitionerQualificationType>()
            .AddType<PractitionerType>();
    }
}