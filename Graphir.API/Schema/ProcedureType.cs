using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ProcedureType : ObjectType<Procedure>
{
    // TODO: finish Procedure
    protected override void Configure(IObjectTypeDescriptor<Procedure> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
