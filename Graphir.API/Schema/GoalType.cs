using Hl7.Fhir.Model;

using HotChocolate.Types;

using static System.StringComparison;

using static Hl7.Fhir.Model.Goal;

namespace Graphir.API.Schema;

public class GoalType : ObjectType<Goal>
{
    protected override void Configure(IObjectTypeDescriptor<Goal> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.LifecycleStatus);
        descriptor.Field(x => x.AchievementStatus).Type<StringType>();
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();

        descriptor.Field("startDate").Type<DateType>()
            .Resolve(x => x.Parent<Goal>() is { Start: Date value } &&
                          value.TypeName.Equals("Date", OrdinalIgnoreCase)
                ? value : null);
        
        descriptor.Field("startCodeableConcept").Type<CodeableConceptType>() 
            .Resolve(x => x.Parent<Goal>() is { Start: CodeableConcept value } &&
                          value.TypeName.Equals("CodeableConcept", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field(x => x.StatusDate);
        descriptor.Field(x => x.StatusReason);
        descriptor.Field(x => x.Target).Type<ListType<GoalTargetComponentType>>();
        descriptor.Field(x => x.ResourceBase).Type<FhirUriType>();
        descriptor.Field(x => x.Addresses).Type<ListType<ResourceReferenceType<GoalAddressesReferenceType>>>();
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.OutcomeCode);
        descriptor.Field(x => x.OutcomeReference);
    }
}

public class GoalAddressesReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("GoalAddressesReferenceType");
        descriptor.Description(
            "Issues addressed by this goal. Reference(Condition | Observation | MedicationStatement | NutritionOrder | ServiceRequest | RiskAssessment)");

        descriptor.Type<ConditionType>();
        descriptor.Type<ServiceRequestType>();
        /* TODO: Add below types
        descriptor.Type<ObservationType>();
        descriptor.Type<MedicationStatementType>();
        descriptor.Type<NutritionOrderType>();
        descriptor.Type<RiskAssessmentType>();
        */
    }
}

public class GoalTargetComponentType : ObjectType<TargetComponent>
{
    protected override void Configure(IObjectTypeDescriptor<TargetComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Measure);
       
        descriptor.Field("detailQuantity").Type<QuantityType>()
            .Resolve(x => x.Parent<TargetComponent>() is { Detail: Quantity value } &&
                          value.TypeName.Equals("Quantity", OrdinalIgnoreCase)
                ? value : null);
        
        descriptor.Field("detailRange").Type<RangeType>() 
            .Resolve(x => x.Parent<TargetComponent>() is { Detail: Range value } &&
                          value.TypeName.Equals("Range", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("detailCodeableConcept").Type<CodeableConceptType>() 
            .Resolve(x => x.Parent<TargetComponent>() is { Detail: CodeableConcept value } &&
                          value.TypeName.Equals("CodeableConcept", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("detailString").Type<StringType>() 
            .Resolve(x => x.Parent<TargetComponent>() is { Detail: FhirString value } &&
                          value.TypeName.Equals("String", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("detailBoolean").Type<BooleanType>() 
            .Resolve(x => x.Parent<TargetComponent>() is { Detail: FhirBoolean value } &&
                          value.TypeName.Equals("Boolean", OrdinalIgnoreCase) 
                ? value : null);

        descriptor.Field("dueDate").Type<DateType>()
            .Resolve(x => x.Parent<TargetComponent>() is { Due: Date value } &&
                          value.TypeName.Equals("Date", OrdinalIgnoreCase)
                ? value : null);
        
        descriptor.Field("dueDuration").Type<DurationType>() 
            .Resolve(x => x.Parent<TargetComponent>() is { Due: Duration value } &&
                          value.TypeName.Equals("Duration", OrdinalIgnoreCase) 
                ? value : null);
    }
}