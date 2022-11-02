using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class AllergyIntoleranceType : ObjectType<AllergyIntolerance>
{
    protected override void Configure(IObjectTypeDescriptor<AllergyIntolerance> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
