using Hl7.Fhir.Model;
using HotChocolate;
using HotChocolate.Types;
using System.Threading;
using Graphir.API.DataLoaders;

namespace Graphir.API.Schema;

public class AppointmentType : ObjectType<Appointment>
{
    protected override void Configure(IObjectTypeDescriptor<Appointment> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Status).Type<EnumType<Appointment.AppointmentStatus>>();
        descriptor.Field(x => x.ServiceType).Type<ListType<CodeableConceptType>>();

        descriptor.Field(x => x.Start).Type<DateTimeType>();
        descriptor.Field(x => x.End).Type<DateTimeType>();
        
        descriptor.Field(x => x.Created).Type<StringType>();
        descriptor.Field(x => x.Comment).Type<StringType>();
        descriptor.Field(x => x.Description).Type<StringType>();
        descriptor.Field(x => x.Priority).Type<IntType>();
        descriptor.Field(x => x.MinutesDuration).Type<IntType>();
        descriptor.Field(x => x.AppointmentType).Type<CodeableConceptType>();
        descriptor.Field(x => x.ReasonCode).Type<ListType<CodeableConceptType>>();

        descriptor.Field(x => x.CommentElement).Type<FhirStringType>();
        descriptor.Field(x => x.ServiceCategory).Type<ListType<CodeableConceptType>>();
      
        descriptor.Field(x => x.Participant).Type<ListType<AppointmentParticipantType>>();
    }
 
}

public class AppointmentParticipantType : ObjectType<Appointment.ParticipantComponent>
{

    protected override void Configure(IObjectTypeDescriptor<Appointment.ParticipantComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Period).Type<PeriodType>();
        descriptor.Field(x => x.Required).Type<BooleanType>();
        descriptor.Field(x => x.Status).Type<StringType>().ResolveWith<AppointmentResolvers>(t => t.GetStatus(default!, default));

        descriptor.Field(x => x.Actor).Type<ResourceReferenceType<AppointmentParticipantActorReferenceType>>();
    }

    private class AppointmentResolvers
    {
        public string GetStatus(
            [Parent] Appointment.ParticipantComponent participant,
            CancellationToken cancellationToken)
        {
            return participant.Status.Value.ToString();
        }
    }
    
}


public class AppointmentParticipantActorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("AppointmentParticipantActorReference");
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<HealthcareServiceType>();
        descriptor.Type<LocationType>();
    }
}
