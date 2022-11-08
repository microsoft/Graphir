using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ClaimResponseType : ObjectType<ClaimResponse>
{
    protected override void Configure(IObjectTypeDescriptor<ClaimResponse> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}