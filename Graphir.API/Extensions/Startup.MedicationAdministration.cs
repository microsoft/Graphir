using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MedicationAdministration = Hl7.Fhir.Model.MedicationAdministration;

namespace Graphir.API.Extensions;

internal static class MedicationAdministrationStartup
{
    public static IRequestExecutorBuilder AddMedicationAdministration
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<MedicationAdministration>>()
            .AddTypeExtension<ResourceQuery<MedicationAdministration, MedicationAdministrationType>>()
            .AddType<MedicationAdministrationType>();
    }
}