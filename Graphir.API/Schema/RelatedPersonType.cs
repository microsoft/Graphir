using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class RelatedPersonType : ObjectType<RelatedPerson>
{
    // TODO: finish RelatedPerson
    protected override void Configure(IObjectTypeDescriptor<RelatedPerson> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(r => r.Id);
    }
}
