using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class AppointmentStartup
{
    public static IRequestExecutorBuilder AddAppointment(this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Hl7.Fhir.Model.Appointment>>()
            .AddTypeExtension<ResourceQuery<Hl7.Fhir.Model.Appointment, AppointmentType>>()
            .AddType<AppointmentType>();
    }
    
}