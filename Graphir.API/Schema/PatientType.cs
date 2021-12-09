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

            descriptor
                .Field(p => p.Gender)
                .Name("gender");

            descriptor.Field(p => p.BirthDate);
            descriptor.Field(p => p.Telecom);
            descriptor.Field(p => p.Address);
            descriptor.Field(p => p.MaritalStatus);
            descriptor.Field(p => p.Photo);


            /*
            implicitRules: uri _implicitRules: ElementBase
            contained: [Resource]
                  deceasedBoolean: Boolean _deceasedBoolean: ElementBase
                 deceasedDateTime: dateTime _deceasedDateTime: ElementBase
                    multipleBirthBoolean: Boolean _multipleBirthBoolean: ElementBase
                   multipleBirthInteger: Int _multipleBirthInteger: ElementBase
                  photo: [Attachment]
                    contact:[PatientContact]
                    communication:[PatientCommunication]
                    generalPractitioner:[Reference]
                    managingOrganization: Reference
                    link: [PatientLink]
            */
        }
    }

}
