using Graphir.API.DataLoaders;
using Graphir.API.Patients;
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
                .AddType<PatientCreation>()
                .AddType<PatientUpdate>()
                .AddType<PatientDelete>()
                .AddType<PatientType>();
    }
}