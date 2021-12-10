using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class PatientType : ObjectType<Patient>
    {
        protected override void Configure(IObjectTypeDescriptor<Patient> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(p => p.Id);
            //descriptor.Field(p => p.Meta);
            descriptor.Field(p => p.Identifier);
            descriptor.Field(p => p.Active);
            descriptor.Field(p => p.Name);
            descriptor.Field(p => p.Language);
            descriptor.Field(p => p.Gender);
            descriptor.Field(p => p.BirthDate);
            descriptor.Field(p => p.Telecom);
            descriptor.Field(p => p.Address);
            descriptor.Field(p => p.MaritalStatus);
            descriptor.Field(p => p.Photo);
            //descriptor.Field(p => p.Contact); #TODO: use resolver to get related resource
            descriptor.Field(p => p.Communication);
            //descriptor.Field(p => p.GeneralPractitioner); #TODO: use resolver to get related resource
            //descriptor.Field(p => p.ManagingOrganization); #TODO: use resolver to get related resource

            /*
            implicitRules: uri _implicitRules: ElementBase
            contained: [Resource]
                  deceasedBoolean: Boolean _deceasedBoolean: ElementBase
                 deceasedDateTime: dateTime _deceasedDateTime: ElementBase
                    multipleBirthBoolean: Boolean _multipleBirthBoolean: ElementBase
                   multipleBirthInteger: Int _multipleBirthInteger: ElementBase
                    link: [PatientLink]
            */
        }
    }

    public class PatientContactType : ObjectType<Patient.ContactComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Patient.ContactComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Address);
            descriptor.Field(c => c.Gender);
            descriptor.Field(c => c.Name);
            descriptor.Field(c => c.Organization.Url)
                .Name("organization");
            descriptor.Field(c => c.Period);
            descriptor.Field(c => c.Relationship);
            descriptor.Field(c => c.Telecom);
        }
    }

    public class PatientCommunicationType : ObjectType<Patient.CommunicationComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Patient.CommunicationComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Language);
            descriptor.Field(c => c.Preferred);
        }
    }

    public class PatientCreation : ResourceCreation<Patient>
    {
        public override Patient Resource { get; set; }
    }

    public class PatientUpdate : ResourceUpdate<Patient>
    {
        public override Patient Resource { get; set; }
    }

    public class PatientDelete : ResourceDelete<Patient> { }

}
