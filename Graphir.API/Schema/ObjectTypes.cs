using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class IdentifierType : ObjectType<Identifier>
    {
        protected override void Configure(IObjectTypeDescriptor<Identifier> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(i => i.Use);
            descriptor.Field(i => i.Type);
            descriptor.Field(i => i.System);
            descriptor.Field(i => i.Value);
        }
    }

    public class CodeableConceptType : ObjectType<CodeableConcept>
    {
        protected override void Configure(IObjectTypeDescriptor<CodeableConcept> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Coding);
            descriptor.Field(c => c.Text);
        }
    }

    public class CodingType : ObjectType<Coding>
    {
        protected override void Configure(IObjectTypeDescriptor<Coding> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Code);
            descriptor.Field(c => c.Display);
            descriptor.Field(c => c.System);
            descriptor.Field(c => c.TypeName);
            descriptor.Field(c => c.UserSelected);
            descriptor.Field(c => c.Version);
        }
    }

    public class HumanNameType : ObjectType<HumanName>
    {
        protected override void Configure(IObjectTypeDescriptor<HumanName> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(h => h.Family);
            descriptor.Field(h => h.Given);
            descriptor.Field(h => h.Period);
            descriptor.Field(h => h.Prefix);
        }
    }

    public class PeriodType : ObjectType<Period>
    {
        protected override void Configure(IObjectTypeDescriptor<Period> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(p => p.End);
            descriptor.Field(p => p.Start);
        }
    }

}
