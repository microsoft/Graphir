using Graphir.API.DataLoaders;
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
                descriptor.Field("substanceCodeableConcept").Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Substance.IngredientComponent>().Substance));
                descriptor.Field("substanceReference").Type<ResourceReferenceType<SubstanceReferenceType>>()
                    .Resolve(r => DataTypeResolvers.GetReferenceValue(r.Parent<Substance.IngredientComponent>().Substance));
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
