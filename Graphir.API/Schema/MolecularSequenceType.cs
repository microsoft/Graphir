using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MolecularSequenceType : ObjectType<MolecularSequence>
{
    protected override void Configure(IObjectTypeDescriptor<MolecularSequence> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}