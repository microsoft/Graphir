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
      
        //TODO: need to add participant resolvers 
        //descriptor.Field(x => x.Participant);
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

// type AppointmentParticipant {
public class AppointmentParticipantType : ObjectType<Appointment.ParticipantComponent> // ???
{

    protected override void Configure(IObjectTypeDescriptor<Appointment.ParticipantComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.ElementId).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Extension).Type<ExtensionType>();
        descriptor.Field(x => x.ModifierExtension).Type<ExtensionType>();
        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Period).Type<PeriodType>();
        descriptor.Field(x => x.Status).Type<CodeType>();

        // WIP, commenting out for now to preserve compilation
        // actor: Reference
        //descriptor.Field(x => x.Actor).Type<ActorType>();
        //descriptor.Field(x => x.Required).Type<BooleanType>();
        // status: code  _status: ElementBase
    }
}

// todo: finish implementing
public class ActorType // : ObjectType<> // ???
{

    //protected override void Configure(IObjectTypeDescriptor<> descriptor)
    //{
    //    descriptor.BindFieldsExplicitly();

    //    // todo: add other descriptors
    //}

    /*
     
            // Summary:
            //     Person, Location/HealthcareService or Device
            [FhirElement("actor", InSummary = true, Order = 50)]
            [CLSCompliant(false)]
            [References(new string[] { "Patient", "Practitioner", "PractitionerRole", "RelatedPerson", "Device", "HealthcareService", "Location" })]
            [DataMember]
            public ResourceReference Actor
            {
                get
                {
                    return _Actor;
                }
                set
                {
                    _Actor = value;
                    OnPropertyChanged("Actor");
                }
            }
     
     */
}


// todo: finish implementing
public class CodeType : ObjectType<Code<ParticipationStatus>> // ???
{

    protected override void Configure(IObjectTypeDescriptor<Code<ParticipationStatus>> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        // todo: add other descriptors
    }

    /*
     
           // Summary:
            //     accepted | declined | tentative | needs-action
            [FhirElement("status", InSummary = true, Order = 70)]
            [DeclaredType(Type = typeof(Code))]
            [Cardinality(Min = 1, Max = 1)]
            [DataMember]
            public Code<ParticipationStatus> StatusElement
            {
                get
                {
                    return _StatusElement;
                }
                set
                {
                    _StatusElement = value;
                    OnPropertyChanged("StatusElement");
                }
            }
     
     */
}
