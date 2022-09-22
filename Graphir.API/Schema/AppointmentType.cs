using Hl7.Fhir.Model;
using HotChocolate.Types;

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
}


