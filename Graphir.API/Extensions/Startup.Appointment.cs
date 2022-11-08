using Graphir.API.DataLoaders;
using Graphir.API.Queries;
using Graphir.API.Schema;

using HotChocolate.Execution.Configuration;

using Microsoft.Extensions.DependencyInjection;

using Appointment = Hl7.Fhir.Model.Appointment;

namespace Graphir.API.Extensions;

internal static class AppointmentStartup
{
    public static IRequestExecutorBuilder AddAppointment(this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddDataLoader<ResourceByIdDataLoader<Appointment>>()
            .AddTypeExtension<AppointmentQuery>()
            .AddType<AppointmentType>();
    }
}