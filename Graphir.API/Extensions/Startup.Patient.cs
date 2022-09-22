using Graphir.API.Patients;
using Graphir.API.Practitioners;
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
            .AddDataLoader<PatientByIdDataLoader>()
            .AddType<PatientCommunicationType>()
            .AddType<PatientContactType>()
            .AddType<PatientCreation>()
            .AddType<PatientUpdate>()
            .AddType<PatientDelete>()
            .AddType<PatientType>();
    }
}