using Graphir.API.Queries;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class MedicationRequestStartup
{
    public static IRequestExecutorBuilder AddMedicationRequest
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<MedicationRequestQuery>()
            .AddType<MedicationRequestType>()
            .AddType<DosageType>()
            .AddType<DoseAndRateType>()
            .AddType<TimingType>()
            .AddType<RepeatComponentType>()
            .AddType<AnnotationType>();
    }
}