using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class GoalType : ObjectType<Goal>
{
    protected override void Configure(IObjectTypeDescriptor<Goal> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.LifecycleStatus);
        descriptor.Field(x => x.AchievementStatus);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<GoalSubjectReferenceType>>();
        descriptor.Field("startDate").Resolve(r => DataTypeResolvers.GetDateValue(r.Parent<Goal>().Start));
        descriptor.Field("startCodeableConcept").Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Goal>().Start));
        descriptor.Field(x => x.Target).Type<ListType<GoalTargetType>>();
        descriptor.Field(x => x.StatusDate);
        descriptor.Field(x => x.StatusReason);
        descriptor.Field(x => x.Addresses).Type<ListType<ResourceReferenceType<GoalAddressesReferenceType>>>();
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.OutcomeCode);
        descriptor.Field(x => x.OutcomeReference).Type<ListType<ResourceReferenceType<ObservationReferenceType>>>();
    }

    private class GoalSubjectReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("GoalSubjectReference");
            descriptor.Description("Reference(Patient | Group | Organization)");
            descriptor.Type<PatientType>();
            descriptor.Type<GroupType>();
            descriptor.Type<OrganizationType>();
        }
    }

    private class GoalTargetType : ObjectType<Goal.TargetComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Goal.TargetComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("GoalTarget");
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Measure);
            descriptor.Field("detailQuantity").Resolve(r => DataTypeResolvers.GetValue<Quantity>(r.Parent<Goal.TargetComponent>().Detail));
            descriptor.Field("detailRange").Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<Goal.TargetComponent>().Detail));
            descriptor.Field("detailCodeableConcept").Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Goal.TargetComponent>().Detail));
            descriptor.Field("detailString").Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<Goal.TargetComponent>().Detail));
            descriptor.Field("detailBoolean").Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<Goal.TargetComponent>().Detail));
            descriptor.Field("detailInteger").Resolve(r => DataTypeResolvers.GetIntegerValue(r.Parent<Goal.TargetComponent>().Detail));
            descriptor.Field("detailRatio").Resolve(r => DataTypeResolvers.GetValue<Ratio>(r.Parent<Goal.TargetComponent>().Detail));
            descriptor.Field("dueDate").Resolve(r => DataTypeResolvers.GetDateValue(r.Parent<Goal.TargetComponent>().Due));
            descriptor.Field("dueDuration").Resolve(r => DataTypeResolvers.GetValue<Duration>(r.Parent<Goal.TargetComponent>().Due));
        }
    }

    private class GoalAddressesReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("GoalAddressesReferenceType");
            descriptor.Description("Reference(Condition | Observation | MedicationStatement | NutritionOrder | ServiceRequest | RiskAssessment)");
            descriptor.Type<ConditionType>();
            descriptor.Type<ObservationType>();
            descriptor.Type<MedicationStatementType>();
            descriptor.Type<NutritionOrderType>();
            descriptor.Type<ServiceRequestType>();
            descriptor.Type<RiskAssessmentType>();
        }
    }
}
