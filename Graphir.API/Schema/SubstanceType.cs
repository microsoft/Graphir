using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class SubstanceType : ObjectType<Substance>
    {
        protected override void Configure(IObjectTypeDescriptor<Substance> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Meta);
            descriptor.Field(x => x.Language);
            descriptor.Field(x => x.Text);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Identifier);
            descriptor.Field(x => x.Instance).Type<InstanceComponentType>();
            descriptor.Field(x => x.Status);
            descriptor.Field(x => x.Category);
            descriptor.Field(x => x.Code);
            descriptor.Field(x => x.Description);
            descriptor.Field(x => x.Ingredient).Type<IngredientComponentType>();
        }

        private class IngredientComponentType : ObjectType<Substance.IngredientComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Substance.IngredientComponent> descriptor)
            {
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Quantity);
                descriptor.Field("substanceCodeableConcept").Type<CodeableConceptType>().Resolve(r =>
                {
                    var parent = r.Parent<Substance.IngredientComponent>();
                    return parent.Substance is not null && parent.Substance.TypeName == "CodeableConcept"
                    ? (CodeableConcept)parent.Substance
                    : null;
                });
                descriptor.Field("substanceReference").Type<ResourceReferenceType<SubstanceReferenceType>>().Resolve(r =>
                {
                    var parent = r.Parent<Substance.IngredientComponent>();
                    return parent.Substance is not null && parent.Substance.TypeName == "Reference"
                    ? (ResourceReference)parent.Substance
                    : null;
                });
            }
        }

        private class InstanceComponentType : ObjectType<Substance.InstanceComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Substance.InstanceComponent> descriptor)
            {
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.Identifier);
                descriptor.Field(x => x.Expiry);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Quantity);
            }
        }

        private class SubstanceReferenceType : UnionType
        {
            protected override void Configure(IUnionTypeDescriptor descriptor)
            {
                descriptor.Name("SubstanceIngredientSubstanceReference");
                descriptor.Description("Reference(Substance)");
                descriptor.Type<SubstanceType>();
            }
        }
    }
}
