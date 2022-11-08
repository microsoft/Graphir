using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class NutritionOrderType : ObjectType<NutritionOrder>
{
    protected override void Configure(IObjectTypeDescriptor<NutritionOrder> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
    }
}