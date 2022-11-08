using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationType : ObjectType<Medication>
{
    protected override void Configure(IObjectTypeDescriptor<Medication> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Manufacturer).Type<ResourceReferenceType<OrganizationReferenceType>>();
        descriptor.Field(x => x.Amount);
        descriptor.Field(x => x.Form);
        descriptor.Field(x => x.Ingredient).Type<ListType<MedicationIngredientType>>();
        descriptor.Field(x => x.Batch).Type<MedicationBatchType>();
    }
}

public class MedicationBatchType : ObjectType<Medication.BatchComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Medication.BatchComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.LotNumber);
        descriptor.Field(x => x.ExpirationDate);
    }
}

public class MedicationIngredientType : ObjectType<Medication.IngredientComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Medication.IngredientComponent> descriptor)
    {
        descriptor.Name("MedicationIngredientComponent");
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Item)
            .Type<CodeableReferenceType<MedicationIngredientItemReferenceType>>()
            .Resolve(context =>
            {
                var parent = context.Parent<Medication.IngredientComponent>();
                return parent.Item is null
                    ? null
                    : parent.Item.TypeName switch
                    {
                        "CodeableConcept" => new CodeableReference { Concept = (CodeableConcept)parent.Item },
                        "Reference" => new CodeableReference { Reference = (ResourceReference)parent.Item },
                        _ => null
                    };
            });
        descriptor.Field(x => x.IsActive);
        descriptor.Field(x => x.Strength);
    }
}

public class MedicationIngredientItemReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationIngredientItemReference");
        descriptor.Description("Reference(Substance | Medication)");
        descriptor.Type<SubstanceType>();
        descriptor.Type<MedicationType>();
    }
}