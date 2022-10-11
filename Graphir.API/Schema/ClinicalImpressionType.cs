using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ClinicalImpressionType : ObjectType<ClinicalImpression>
{
    protected override void Configure(IObjectTypeDescriptor<ClinicalImpression> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Id);
    }
}

#region QueryExtensions
public class ClinicalImpressionQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field(nameof(ClinicalImpression))
            .Type<ClinicalImpressionType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<ClinicalImpression>>(r => r.GetResource(default!, default!));

        descriptor.Field($"{nameof(ClinicalImpression)}List")
            .Type<ListType<ConditionType>>()
            .ResolveWith<ResourceResolvers<ClinicalImpression>>(r => r.GetResources(default!));
    }
}
#endregion
