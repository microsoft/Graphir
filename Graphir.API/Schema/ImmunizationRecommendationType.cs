using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ImmunizationRecommendationType : ObjectType<ImmunizationRecommendation>
{
    protected override void Configure(IObjectTypeDescriptor<ImmunizationRecommendation> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
