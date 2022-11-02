using Graphir.API.DataLoaders;
using Graphir.API.Schema;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Queries;

public class AppointmentQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("Appointment")
                .Type<AppointmentType>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<Appointment>>(r => r.GetResource(default!, default!));

        descriptor.Field("AppointmentList")
            .Type<ListType<AppointmentType>>()
            .Argument("patient", a => a.Type<StringType>())
            .Argument("practitioner", a => a.Type<StringType>())
            .Argument("date", a => a.Type<DateType>())
            .ResolveWith<AppointmentResolvers>(r => r.GetAppointmentListResources(default!, default, default, default));
    }
}
