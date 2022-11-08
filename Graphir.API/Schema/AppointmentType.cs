using Hl7.Fhir.Model;

using HotChocolate;
using HotChocolate.Types;

using System.Threading;

namespace Graphir.API.Schema;

public class AppointmentType : ObjectType<Appointment>
{
    protected override void Configure(IObjectTypeDescriptor<Appointment> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Status).Type<EnumType<Appointment.AppointmentStatus>>(); // need forced enum type here
        descriptor.Field(x => x.ServiceType);

        descriptor.Field(x => x.Start);
        descriptor.Field(x => x.End);

        descriptor.Field(x => x.Created);
        descriptor.Field(x => x.Comment);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.MinutesDuration);
        descriptor.Field(x => x.AppointmentType);
        descriptor.Field(x => x.ReasonCode);

        descriptor.Field(x => x.CommentElement).Type<FhirStringType>(); // must force FhirStringType here
        descriptor.Field(x => x.ServiceCategory);

        descriptor.Field(x => x.Participant).Type<ListType<AppointmentParticipantType>>();
    }
}

public class AppointmentParticipantType : ObjectType<Appointment.ParticipantComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Appointment.ParticipantComponent> descriptor)
    {
        descriptor.Name("AppointmentParticipantComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Period).Type<PeriodType>();
        descriptor.Field(x => x.Required).Type<BooleanType>();
        descriptor.Field(x => x.Status).Type<StringType>()
            .ResolveWith<AppointmentResolvers>(t => t.GetStatus(default!, default));

        descriptor.Field(x => x.Actor).Type<ResourceReferenceType<AppointmentParticipantActorReferenceType>>();
    }

    private class AppointmentResolvers
    {
        public string GetStatus(
            [Parent] Appointment.ParticipantComponent participant,
            CancellationToken cancellationToken)
        {
            return participant.Status!.Value.ToString();
        }
    }
}

public class AppointmentParticipantActorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("AppointmentParticipantActorReference");
        descriptor.Description(
            "The type of actor Reference(Person | Location | HealthcareService | Device) that is participating in the appointment");
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<HealthcareServiceType>();
        descriptor.Type<LocationType>();
    }
}