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

public class SubjectReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SubjectReference");
        descriptor.Description("Reference(Patient | Group)");
        descriptor.Type<PatientType>();
        descriptor.Type<GroupType>();
    }
}
