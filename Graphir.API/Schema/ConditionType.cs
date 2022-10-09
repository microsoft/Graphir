using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class ConditionType : ObjectType<Condition>
    {
        // TODO: code review demo
        protected override void Configure(IObjectTypeDescriptor<Condition> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Id);
        }
    }
}
