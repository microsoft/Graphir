using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class CoverageType : ObjectType<Coverage>
    {
        protected override void Configure(IObjectTypeDescriptor<Coverage> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Id);
        }
    }
}
