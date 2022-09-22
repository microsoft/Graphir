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

public class QuantityType : ObjectType<Quantity>
{
    protected override void Configure(IObjectTypeDescriptor<Quantity> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Value).Type<DecimalType>();
        descriptor.Field(x => x.Comparator).Type<StringType>();
        descriptor.Field(x => x.Unit).Type<StringType>();
        descriptor.Field(x => x.System).Type<StringType>();
        descriptor.Field(x => x.Code).Type<StringType>();
    }
}

/*public class ReferenceType : ObjectType<Organization>
{
    protected override void Configure(IObjectTypeDescriptor<Organization> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Active).Type<BooleanType>();
        descriptor.Field(x => x.Type).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field(x => x.Telecom).Type<ListType<ContactPointType>>();
        descriptor.Field(x => x.Address).Type<ListType<AddressType>>();
        descriptor.Field(x => x.PartOf).Type<ReferenceType>();
        descriptor.Field(x => x.Contact).Type<ListType<OrganizationContactType>>();
        descriptor.Field(x => x.Endpoint).Type<ListType<ReferenceType>>();
    }
}

public class OrganizationContactType : ObjectType<Organization.ContactComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Organization.ContactComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Purpose).Type<CodeableConceptType>();
        descriptor.Field(x => x.Name).Type<HumanNameType>();
        descriptor.Field(x => x.Telecom).Type<ListType<ContactPointType>>();
        descriptor.Field(x => x.Address).Type<AddressType>();
    }
}*/

