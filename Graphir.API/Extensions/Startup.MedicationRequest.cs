using Graphir.API.DataLoaders;
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
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.MedicationRequest>>()
            .AddType<MedicationRequestType>()
            .AddType<DosageType>()
            .AddType<DoseAndRateType>()
            .AddType<TimingType>()
            .AddType<RepeatComponentType>()
            ;
    }
}