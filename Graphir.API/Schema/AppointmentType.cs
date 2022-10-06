using Graphir.API.Practitioners;
using Hl7.Fhir.Model;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

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


// type AppointmentParticipant {
public class AppointmentParticipantType : ObjectType<Appointment.ParticipantComponent>
{

    protected override void Configure(IObjectTypeDescriptor<Appointment.ParticipantComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Period).Type<PeriodType>();
        descriptor.Field(x => x.Required).Type<BooleanType>();
        descriptor.Field(x => x.Status).Type<CodeType>();

        descriptor.Field(x => x.Actor).Type<ActorType>()
            .ResolveWith<AppointmentResolvers>(t => t.GetActorAsync(default!, default));

        // WIP, commenting out for now to preserve compilation
        // actor: Reference
        // status: code  _status: ElementBase
    }

    private class AppointmentResolvers
    {
        public async Task<object> GetActorAsync(
            [Parent] Appointment.ParticipantComponent participant,
            
            CancellationToken cancellationToken)
        {
            var refTokens = participant.Actor.Reference.Split('/');
            var idToken = refTokens.LastOrDefault();



        }
    }
    //private class PatientResolvers
    //{
    //    public async Task<IReadOnlyList<Practitioner>> GetApppointmentAsync(
    //        [Parent] Appointment patient,
    //        PractitionerByIdDataLoader practitionerById,
    //        CancellationToken cancellationToken
    //    )
    //    {
    //        var refs = patient.GeneralPractitioner.Select(p => p.Reference.Split('/').LastOrDefault());

    //        var results = await practitionerById.LoadAsync(refs.ToArray(), cancellationToken);

    //        return results;
    //    }
    //}
}

public class ActorType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("Actor");
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        //descriptor.Type<PractitionerRoleType>();
        //descriptor.Type<RelatedPersonType>();
        //descriptor.Type<DeviceType>();
        descriptor.Type<HealthcareServiceType>();
        descriptor.Type<LocationType>();
    }
    
}

public class CodeType : ObjectType<Code<ParticipationStatus>>
{
    protected override void Configure(IObjectTypeDescriptor<Code<ParticipationStatus>> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Value);

    }

}
