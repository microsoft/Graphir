using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class RelatedPersonType : ObjectType<RelatedPerson>
{
    protected override void Configure(IObjectTypeDescriptor<RelatedPerson> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(r => r.Id);
        descriptor.Field(r => r.Meta);
        descriptor.Field(r => r.ImplicitRules);
        descriptor.Field(r => r.Language);
        descriptor.Field(r => r.Text);
        descriptor.Field(r => r.Contained);
        descriptor.Field(r => r.Extension);
        descriptor.Field(r => r.ModifierExtension);
        descriptor.Field(r => r.Identifier);
        descriptor.Field(r => r.Active);
        descriptor.Field(r => r.Patient).Type<ResourceReferenceType<PatientReferenceType>>();
        descriptor.Field(r => r.Relationship);
        descriptor.Field(r => r.Name);
        descriptor.Field(r => r.Telecom);
        descriptor.Field(r => r.Gender);
        descriptor.Field(r => r.BirthDate);
        descriptor.Field(r => r.Address);
        descriptor.Field(r => r.Photo);
        descriptor.Field(r => r.Period);
        descriptor.Field(r => r.Communication).Type<ListType<RelatedPersonCommunicationType>>();
    }

    private class RelatedPersonCommunicationType : ObjectType<RelatedPerson.CommunicationComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<RelatedPerson.CommunicationComponent> descriptor)
        {
            descriptor.Name("RelatedPersonCommunication");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Language);
            descriptor.Field(x => x.Preferred);
        }
    }
}