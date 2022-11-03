using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ClaimType : ObjectType<Claim>
{
    // TODO: finish ClaimType
    protected override void Configure(IObjectTypeDescriptor<Claim> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
    }
}
