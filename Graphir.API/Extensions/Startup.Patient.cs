namespace Graphir.API.Extensions;

internal static class PatientStartup
{
    public static IRequestExecutorBuilder AddPatient(
        this IRequestExecutorBuilder graphBuilder)
    {
        graphBuilder
            .AddDataLoader<PatientByIdDataLoader>()
            .AddType<PatientCommunicationType>()
            .AddType<PatientContactType>()
            .AddType<PatientCreation>()
            .AddType<PatientUpdate>()
            .AddType<PatientDelete>()
            .AddType<PatientType>();

        return graphBuilder;
    }
}