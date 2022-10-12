using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MedicationRequest = Hl7.Fhir.Model.MedicationRequest;

namespace Graphir.API.Extensions;

internal static class MedicationRequestStartup
{
    public static IRequestExecutorBuilder AddMedicationRequest
        (this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddTypeExtension<ResourceQuery<MedicationRequest, MedicationRequestType>>()
            .AddDataLoader<ResourceByIdDataLoader<MedicationRequest>>()
            .AddType<MedicationRequestType>()            
            ;
    }
}