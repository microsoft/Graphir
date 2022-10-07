using Graphir.API.Schema;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graphir.API.Extensions;

internal static class AppointmentStartup
{
    public static IRequestExecutorBuilder AddAppointment(this IRequestExecutorBuilder graphBuilder)
    {
        return graphBuilder
            .AddType<AppointmentType>()
            .AddType<AppointmentParticipantType>()
            .AddType<ActorReferenceType>();
    }
    
}