using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class PlanDefinitionType : ObjectType<PlanDefinition>
{
    protected override void Configure(IObjectTypeDescriptor<PlanDefinition> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Url);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Version);
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Title);
        descriptor.Field(x => x.Subtitle);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Experimental);
        descriptor.Field("subjectCodeableConcept")
            .Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<PlanDefinition>().Subject));
        descriptor.Field("subjectReference").Type<ResourceReferenceType<GroupReferenceType>>()
            .Resolve(r => DataTypeResolvers.GetValue<ResourceReference>(r.Parent<PlanDefinition>().Subject));
        descriptor.Field("subjectCanonical")
            .Resolve(r => DataTypeResolvers.GetCanonicalValue(r.Parent<PlanDefinition>().Subject));
        descriptor.Field(x => x.Date);
        descriptor.Field(x => x.Publisher);
        descriptor.Field(x => x.Contact);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.UseContext);
        descriptor.Field(x => x.Jurisdiction);
        descriptor.Field(x => x.Purpose);
        descriptor.Field(x => x.Usage);
        descriptor.Field(x => x.Copyright);
        descriptor.Field(x => x.ApprovalDate);
        descriptor.Field(x => x.LastReviewDate);
        descriptor.Field(x => x.EffectivePeriod);
        descriptor.Field(x => x.Topic);
        descriptor.Field(x => x.Author);
        descriptor.Field(x => x.Editor);
        descriptor.Field(x => x.Reviewer);
        descriptor.Field(x => x.Endorser);
        descriptor.Field(x => x.RelatedArtifact);
        descriptor.Field(x => x.Library);
        descriptor.Field(x => x.Goal).Type<PlanDefinitionGoalType>();
        descriptor.Field(x => x.Action).Type<PlanDefinitionActionType>();
    }

    private class PlanDefinitionGoalType : ObjectType<PlanDefinition.GoalComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<PlanDefinition.GoalComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Category);
            descriptor.Field(x => x.Description);
            descriptor.Field(x => x.Priority);
            descriptor.Field(x => x.Addresses);
            descriptor.Field(x => x.Documentation);
            descriptor.Field(x => x.Target).Type<PlanDefinitionGoalTargetType>();
        }

        private class PlanDefinitionGoalTargetType : ObjectType<PlanDefinition.TargetComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<PlanDefinition.TargetComponent> descriptor)
            {
                descriptor.BindFieldsExplicitly();
                descriptor.Name("PlanDefinitionGoalTarget");
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Measure);
                descriptor.Field("detailQuantity")
                    .Resolve(r => DataTypeResolvers.GetValue<Quantity>(r.Parent<PlanDefinition.TargetComponent>().Detail));
                descriptor.Field("detailRange")
                    .Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<PlanDefinition.TargetComponent>().Detail));
                descriptor.Field("detailCodeableConcept")
                    .Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<PlanDefinition.TargetComponent>().Detail));
                descriptor.Field("detailString")
                    .Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<PlanDefinition.TargetComponent>().Detail));
                descriptor.Field("detailBoolean")
                    .Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<PlanDefinition.TargetComponent>().Detail));
                descriptor.Field("detailInteger")
                    .Resolve(r => DataTypeResolvers.GetIntegerValue(r.Parent<PlanDefinition.TargetComponent>().Detail));
                descriptor.Field("detailRatio")
                    .Resolve(r => DataTypeResolvers.GetValue<Ratio>(r.Parent<PlanDefinition.TargetComponent>().Detail));
                descriptor.Field(x => x.Due);
            }
        }
    }

    private class PlanDefinitionActionType : ObjectType<PlanDefinition.ActionComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<PlanDefinition.ActionComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Prefix);
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Description);
            descriptor.Field(x => x.TextEquivalent);
            descriptor.Field(x => x.Priority);
            descriptor.Field(x => x.Code);
            descriptor.Field(x => x.Reason);
            descriptor.Field(x => x.Documentation);
            descriptor.Field(x => x.GoalId);
            descriptor.Field("subjectCodeableConcept")
                .Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<PlanDefinition.ActionComponent>().Subject));
            descriptor.Field("subjectReference").Type<GroupReferenceType>()
                .Resolve(r => DataTypeResolvers.GetValue<ResourceReference>(r.Parent<PlanDefinition.ActionComponent>().Subject));
            descriptor.Field("subjectCanonical")
                .Resolve(r => DataTypeResolvers.GetCanonicalValue(r.Parent<PlanDefinition.ActionComponent>().Subject));
            descriptor.Field(x => x.Trigger);
            descriptor.Field(x => x.Condition).Type<ListType<PlanDefinitionActionConditionType>>();
            descriptor.Field(x => x.Input);
            descriptor.Field(x => x.Output);
            descriptor.Field(x => x.RelatedAction).Type<ListType<PlanDefinitionRelatedActionType>>();
            descriptor.Field("timingAge")
                .Resolve(r => DataTypeResolvers.GetValue<Age>(r.Parent<PlanDefinition.ActionComponent>().Timing));
            descriptor.Field("timingDuration")
                .Resolve(r => DataTypeResolvers.GetValue<Duration>(r.Parent<PlanDefinition.ActionComponent>().Timing));
            descriptor.Field("timingRange")
                .Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<PlanDefinition.ActionComponent>().Timing));
            descriptor.Field("timingTiming")
                .Resolve(r => DataTypeResolvers.GetValue<Timing>(r.Parent<PlanDefinition.ActionComponent>().Timing));
            descriptor.Field(x => x.Participant).Type<ListType<PlanDefinitionActionParticipantType>>();
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.GroupingBehavior);
            descriptor.Field(x => x.SelectionBehavior);
            descriptor.Field(x => x.RequiredBehavior);
            descriptor.Field(x => x.PrecheckBehavior);
            descriptor.Field(x => x.CardinalityBehavior);
            descriptor.Field("definitionCanonical")
                .Resolve(r => DataTypeResolvers.GetCanonicalValue(r.Parent<PlanDefinition.ActionComponent>().Definition));
            descriptor.Field("definitionUri")
                .Resolve(r => DataTypeResolvers.GetUriValue(r.Parent<PlanDefinition.ActionComponent>().Definition));
            descriptor.Field(x => x.Transform);
            descriptor.Field(x => x.DynamicValue).Type<ListType<PlanDefinitionActionDynamicValueType>>();
            descriptor.Field(x => x.Action);
        }

        private class PlanDefinitionRelatedActionType : ObjectType<PlanDefinition.RelatedActionComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<PlanDefinition.RelatedActionComponent> descriptor)
            {
                descriptor.BindFieldsExplicitly();
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.ActionId);
                descriptor.Field(x => x.Relationship);
                descriptor.Field("offsetDuration")
                    .Resolve(r => DataTypeResolvers.GetValue<Duration>(r.Parent<PlanDefinition.RelatedActionComponent>().Offset));
                descriptor.Field("offsetRange")
                    .Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<PlanDefinition.RelatedActionComponent>().Offset));

            }
        }

        private class PlanDefinitionActionParticipantType : ObjectType<PlanDefinition.ParticipantComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<PlanDefinition.ParticipantComponent> descriptor)
            {
                descriptor.BindFieldsExplicitly();
                descriptor.Name("PlanDefinitionActionParticipant");
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Type);
                descriptor.Field(x => x.Role);
            }
        }

        private class PlanDefinitionActionDynamicValueType : ObjectType<PlanDefinition.DynamicValueComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<PlanDefinition.DynamicValueComponent> descriptor)
            {
                descriptor.BindFieldsExplicitly();
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Path);
                descriptor.Field(x => x.Expression);
            }
        }

        private class PlanDefinitionActionConditionType : ObjectType<PlanDefinition.ConditionComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<PlanDefinition.ConditionComponent> descriptor)
            {
                descriptor.BindFieldsExplicitly();
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Kind);
                descriptor.Field(x => x.Expression);
            }
        }
    }
}
