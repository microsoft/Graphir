using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ManagingOrganizationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ManagingOrganizationReference");
        descriptor.Type<OrganizationType>();
    }
}
