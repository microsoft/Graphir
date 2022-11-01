using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class CarePlanType : ObjectType<CarePlan>
{
    protected override void Configure(IObjectTypeDescriptor<CarePlan> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.InstantiatesCanonical);
        descriptor.Field(x => x.InstantiatesUri);
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<CarePlanReferenceType>>>();
        descriptor.Field(x => x.Replaces).Type<ListType<ResourceReferenceType<CarePlanReferenceType>>>();
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<CarePlanReferenceType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Intent);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Title);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Id);
    }

    private class CarePlanReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CarePlanReference");
            descriptor.Description("Reference(CarePlan)");
            descriptor.Type<CarePlanType>();
        }
    }
}
