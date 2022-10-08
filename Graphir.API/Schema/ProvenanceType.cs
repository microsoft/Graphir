using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class ProvenanceType : ObjectType<Provenance>
    {
        protected override void Configure(IObjectTypeDescriptor<Provenance> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(p => p.Id);
        }
    }
}
