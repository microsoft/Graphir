using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class PlanDefinitionType : ObjectType<PlanDefinition>
{
    protected override void Configure(IObjectTypeDescriptor<PlanDefinition> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
