using Graphir.API.DataLoaders;
using Graphir.API.Mutations;
using Graphir.API.Queries;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class PatientStartup
{
    public static IRequestExecutorBuilder AddPatient(
        this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Patient>>()
            .AddTypeExtension<PatientMutation>()
            .AddTypeExtension<PatientQuery>()
            .AddType<PatientCommunicationType>()
            .AddType<PatientContactType>()
            .AddType<PatientLinkType>()
            .AddType<PatientCreation>()
            .AddType<PatientUpdate>()
            .AddType<PatientDelete>()
            .AddType<PatientType>();
    }
}