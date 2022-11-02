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
        descriptor.Field("startDate").Type<DateType>().Resolve(r =>
        {
            var parent = r.Parent<Goal>();
            return parent.Start is not null && parent.Start.TypeName == "date" ?
            (Date)parent.Start : null;
        });
        descriptor.Field("startCodeableConcept").Resolve(r =>
        {
            var parent = r.Parent<Goal>();
            return parent.Start is not null && parent.Start.TypeName == "CodeableConcept" ?
            (CodeableConcept)parent.Start : null;
        });
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

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Measure);
            descriptor.Field("detailQuantity").Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Detail is not null && parent.Detail.TypeName == "Quantity" ?
                (Quantity)parent.Detail : null;
            });
            descriptor.Field("detailRange").Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Detail is not null && parent.Detail.TypeName == "Range" ?
                (Range)parent.Detail : null;
            });
            descriptor.Field("detailCodeableConcept").Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Detail is not null && parent.Detail.TypeName == "CodeableConcept" ?
                (CodeableConcept)parent.Detail : null;
            });
            descriptor.Field("detailString").Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Detail is not null && parent.Detail.TypeName == "string" ?
                (FhirString)parent.Detail : null;
            });
            descriptor.Field("detailBoolean").Type<BooleanType>().Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Detail is not null && parent.Detail.TypeName == "boolean" ?
                (FhirBoolean)parent.Detail : null;
            });
            descriptor.Field("detailInteger").Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Detail is not null && parent.Detail.TypeName == "integer" ?
                ((Integer)parent.Detail).Value : null;
            });
            descriptor.Field("detailRatio").Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Detail is not null && parent.Detail.TypeName == "Ratio" ?
                (Ratio)parent.Detail : null;
            });
            descriptor.Field("dueDate").Type<DateType>().Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Due is not null && parent.Due.TypeName == "date" ?
                (Date)parent.Due : null;
            });
            descriptor.Field("dueDuration").Resolve(r =>
            {
                var parent = r.Parent<Goal.TargetComponent>();
                return parent.Due is not null && parent.Due.TypeName == "Duration" ?
                (Duration)parent.Due : null;
            });
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
