using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class EncounterType : ObjectType<Encounter>
{
    // TODO: finish Encounter
    protected override void Configure(IObjectTypeDescriptor<Encounter> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.Id);
    }
}
