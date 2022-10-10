using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationType : ObjectType<Medication>
{
    protected override void Configure(IObjectTypeDescriptor<Medication> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Code).Type<CodeableConceptType>();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.Text).Type<NarrativeType>();
        descriptor.Field(x => x.Form).Type<CodeableConceptType>();
        descriptor.Field(x => x.Amount).Type<RatioType>();
        descriptor.Field(x => x.Ingredient).Type<ListType<MedicationIngredientType>>();
        descriptor.Field(x => x.Batch).Type<MedicationBatchType>();
        //descriptor.Field(x => x.Manufacturer); #TODO: use resolver to get related resource
    }
}

public class NarrativeType : ObjectType<Narrative>
{
    protected override void Configure(IObjectTypeDescriptor<Narrative> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.Div).Type<StringType>();
    }
}

public class MedicationBatchType : ObjectType<Medication.BatchComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Medication.BatchComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.LotNumber).Type<StringType>();
        descriptor.Field(x => x.ExpirationDate).Type<DateType>();
    }
}

public class MedicationIngredientType : ObjectType<Medication.IngredientComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Medication.IngredientComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Item).Type<StringType>();
        descriptor.Field(x => x.IsActive).Type<BooleanType>();
        descriptor.Field(x => x.Strength).Type<RatioType>();
    }
}

public class RatioType : ObjectType<Ratio>
{
    protected override void Configure(IObjectTypeDescriptor<Ratio> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Numerator).Type<QuantityType>();
        descriptor.Field(x => x.Denominator).Type<QuantityType>();
    }
}

#region QueryExtensions
public class MedicationQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("Medication")
            .Type<MedicationType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<Medication>>(r => r.GetResource(default!, default!));

        descriptor.Field("MedicationList")
            .Type<ListType<MedicationType>>()
            .ResolveWith<ResourceResolvers<Medication>>(r => r.GetResources(default!));
    }
}
#endregion
