using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class AllergyIntoleranceType : ObjectType<AllergyIntolerance>
{
    // TODO: finish allergyintolerance
    protected override void Configure(IObjectTypeDescriptor<AllergyIntolerance> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
