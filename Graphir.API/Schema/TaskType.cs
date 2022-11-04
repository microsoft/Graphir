using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class TaskType : ObjectType<Task>
{
    protected override void Configure(IObjectTypeDescriptor<Task> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.InstantiatesCanonical);
        descriptor.Field(x => x.InstantiatesUri);
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
        descriptor.Field(x => x.GroupIdentifier);
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<TaskReferenceType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.StatusReason);
        descriptor.Field(x => x.BusinessStatus);
        descriptor.Field(x => x.Intent);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Focus).Type<ResourceReferenceType<AnyReferenceType>>();
        descriptor.Field(x => x.For).Type<ResourceReferenceType<AnyReferenceType>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field(x => x.ExecutionPeriod);
        descriptor.Field(x => x.AuthoredOn);
        descriptor.Field(x => x.LastModified);
        descriptor.Field(x => x.Requester).Type<ResourceReferenceType<TaskRequesterReferenceType>>();
        descriptor.Field(x => x.PerformerType);
        descriptor.Field(x => x.Owner).Type<ResourceReferenceType<TaskOwnerReferenceType>>();
        descriptor.Field(x => x.Location).Type<ResourceReferenceType<LocationReferenceType>>();
        descriptor.Field(x => x.ReasonCode);
        descriptor.Field(x => x.ReasonReference).Type<ResourceReferenceType<AnyReferenceType>>();
        descriptor.Field(x => x.Insurance).Type<ListType<ResourceReferenceType<InsuranceReferenceType>>>();
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.RelevantHistory).Type<ListType<ResourceReferenceType<ProvenanceReferenceType>>>();
        descriptor.Field(x => x.Restriction).Type<TaskRestrictionType>();
        descriptor.Field(x => x.Input).Type<TaskParameterType>();
        descriptor.Field(x => x.Output).Type<TaskOutputType>();
    }

    private class TaskRequesterReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Description("Reference(Device | Organization | Patient | Practitioner | PractitionerRole | RelatedPerson)");
            descriptor.Type<DeviceType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<PatientType>();
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<RelatedPersonType>();
        }
    }

    private class TaskOwnerReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Description("Reference(Practitioner | PractitionerRole | Organization | CareTeam | HealthcareService | Patient | Device | RelatedPerson)");
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<CareTeamType>();
            descriptor.Type<HealthcareServiceType>();
            descriptor.Type<PatientType>();
            descriptor.Type<DeviceType>();
            descriptor.Type<RelatedPersonType>();
        }
    }

    private class TaskRestrictionType : ObjectType<Task.RestrictionComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Task.RestrictionComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Repetitions);
            descriptor.Field(x => x.Period);
            descriptor.Field(x => x.Recipient).Type<ListType<ResourceReferenceType<TaskRestrictionRecipientReferenceType>>>();
        }

        private class TaskRestrictionRecipientReferenceType : UnionType
        {
            protected override void Configure(IUnionTypeDescriptor descriptor)
            {
                descriptor.Description("Reference(Patient | Practitioner | PractitionerRole | RelatedPerson | Group | Organization)");
                descriptor.Type<PatientType>();
                descriptor.Type<PractitionerType>();
                descriptor.Type<PractitionerRoleType>();
                descriptor.Type<RelatedPersonType>();
                descriptor.Type<GroupType>();
                descriptor.Type<OrganizationType>();
            }
        }
    }

    private class TaskParameterType : ObjectType<Task.ParameterComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Task.ParameterComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Type);

            descriptor.Field("valueBase64Binary")
                .Resolve(r => DataTypeResolvers.GetBase64BinaryValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueBoolean")
                .Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueCanonical")
                .Resolve(r => DataTypeResolvers.GetCanonicalValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueCode")
                .Resolve(r => DataTypeResolvers.GetCodeValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueDate")
                .Resolve(r => DataTypeResolvers.GetDateValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueDateTime")
                .Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueDecimal")
                .Resolve(r => DataTypeResolvers.GetDecimalValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueId")
                .Resolve(r => DataTypeResolvers.GetIdValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueInstant")
                .Resolve(r => DataTypeResolvers.GetInstantValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueInteger")
                .Resolve(r => DataTypeResolvers.GetIntegerValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueInteger64")
                .Resolve(r => DataTypeResolvers.GetInteger64Value(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueMarkdown")
                .Resolve(r => DataTypeResolvers.GetMarkdownValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueOid")
                .Resolve(r => DataTypeResolvers.GetOidValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valuePositiveInt")
                .Resolve(r => DataTypeResolvers.GetPositiveIntValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueString")
                .Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueTime")
                .Resolve(r => DataTypeResolvers.GetTimeValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueUnsignedInt")
                .Resolve(r => DataTypeResolvers.GetUnsignedIntValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueUri")
                .Resolve(r => DataTypeResolvers.GetUriValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueUrl")
                .Resolve(r => DataTypeResolvers.GetUrlValue(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueUuid")
                .Resolve(r => DataTypeResolvers.GetUuidValue(r.Parent<Task.ParameterComponent>().Value));

            descriptor.Field("valueAddress")
                .Resolve(r => DataTypeResolvers.GetValue<Address>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueAge")
                .Resolve(r => DataTypeResolvers.GetValue<Age>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueAnnotation")
                .Resolve(r => DataTypeResolvers.GetValue<Annotation>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueAttachment")
                .Resolve(r => DataTypeResolvers.GetValue<Attachment>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueCodeableConcept")
                .Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueCoding")
                .Resolve(r => DataTypeResolvers.GetValue<Coding>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueContactPoint")
                .Resolve(r => DataTypeResolvers.GetValue<ContactPoint>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueCount")
                .Resolve(r => DataTypeResolvers.GetValue<Count>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueDistance")
                .Resolve(r => DataTypeResolvers.GetValue<Distance>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueDuration")
                .Resolve(r => DataTypeResolvers.GetValue<Duration>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueHumanName")
                .Resolve(r => DataTypeResolvers.GetValue<HumanName>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueIdentifier")
                .Resolve(r => DataTypeResolvers.GetValue<Identifier>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueMoney")
                .Resolve(r => DataTypeResolvers.GetValue<Money>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valuePeriod")
                .Resolve(r => DataTypeResolvers.GetValue<Period>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueQuantity")
                .Resolve(r => DataTypeResolvers.GetValue<Quantity>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueRange")
                .Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueRatio")
                .Resolve(r => DataTypeResolvers.GetValue<Ratio>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueSampledData")
                .Resolve(r => DataTypeResolvers.GetValue<SampledData>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueSignature")
                .Resolve(r => DataTypeResolvers.GetValue<Signature>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueTiming")
                .Resolve(r => DataTypeResolvers.GetValue<Timing>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueContactDetail")
                .Resolve(r => DataTypeResolvers.GetValue<ContactDetail>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueContributor")
                .Resolve(r => DataTypeResolvers.GetValue<Contributor>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueDataRequirement")
                .Resolve(r => DataTypeResolvers.GetValue<DataRequirement>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueExpression")
                .Resolve(r => DataTypeResolvers.GetValue<Expression>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueParameterDefinition")
                .Resolve(r => DataTypeResolvers.GetValue<ParameterDefinition>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueRelatedArtifact")
                .Resolve(r => DataTypeResolvers.GetValue<RelatedArtifact>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueTriggerDefinition")
                .Resolve(r => DataTypeResolvers.GetValue<TriggerDefinition>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueUsageContext")
                .Resolve(r => DataTypeResolvers.GetValue<UsageContext>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueDosage")
                .Resolve(r => DataTypeResolvers.GetValue<Dosage>(r.Parent<Task.ParameterComponent>().Value));
            descriptor.Field("valueMeta")
                .Resolve(r => DataTypeResolvers.GetValue<Meta>(r.Parent<Task.ParameterComponent>().Value));
        }
    }

    private class TaskOutputType : ObjectType<Task.OutputComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Task.OutputComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Type);

            descriptor.Field("valueBase64Binary")
                .Resolve(r => DataTypeResolvers.GetBase64BinaryValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueBoolean")
                .Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueCanonical")
                .Resolve(r => DataTypeResolvers.GetCanonicalValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueCode")
                .Resolve(r => DataTypeResolvers.GetCodeValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueDate")
                .Resolve(r => DataTypeResolvers.GetDateValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueDateTime")
                .Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueDecimal")
                .Resolve(r => DataTypeResolvers.GetDecimalValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueId")
                .Resolve(r => DataTypeResolvers.GetIdValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueInstant")
                .Resolve(r => DataTypeResolvers.GetInstantValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueInteger")
                .Resolve(r => DataTypeResolvers.GetIntegerValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueInteger64")
                .Resolve(r => DataTypeResolvers.GetInteger64Value(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueMarkdown")
                .Resolve(r => DataTypeResolvers.GetMarkdownValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueOid")
                .Resolve(r => DataTypeResolvers.GetOidValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valuePositiveInt")
                .Resolve(r => DataTypeResolvers.GetPositiveIntValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueString")
                .Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueTime")
                .Resolve(r => DataTypeResolvers.GetTimeValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueUnsignedInt")
                .Resolve(r => DataTypeResolvers.GetUnsignedIntValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueUri")
                .Resolve(r => DataTypeResolvers.GetUriValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueUrl")
                .Resolve(r => DataTypeResolvers.GetUrlValue(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueUuid")
                .Resolve(r => DataTypeResolvers.GetUuidValue(r.Parent<Task.OutputComponent>().Value));

            descriptor.Field("valueAddress")
                .Resolve(r => DataTypeResolvers.GetValue<Address>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueAge")
                .Resolve(r => DataTypeResolvers.GetValue<Age>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueAnnotation")
                .Resolve(r => DataTypeResolvers.GetValue<Annotation>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueAttachment")
                .Resolve(r => DataTypeResolvers.GetValue<Attachment>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueCodeableConcept")
                .Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueCoding")
                .Resolve(r => DataTypeResolvers.GetValue<Coding>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueContactPoint")
                .Resolve(r => DataTypeResolvers.GetValue<ContactPoint>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueCount")
                .Resolve(r => DataTypeResolvers.GetValue<Count>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueDistance")
                .Resolve(r => DataTypeResolvers.GetValue<Distance>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueDuration")
                .Resolve(r => DataTypeResolvers.GetValue<Duration>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueHumanName")
                .Resolve(r => DataTypeResolvers.GetValue<HumanName>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueIdentifier")
                .Resolve(r => DataTypeResolvers.GetValue<Identifier>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueMoney")
                .Resolve(r => DataTypeResolvers.GetValue<Money>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valuePeriod")
                .Resolve(r => DataTypeResolvers.GetValue<Period>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueQuantity")
                .Resolve(r => DataTypeResolvers.GetValue<Quantity>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueRange")
                .Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueRatio")
                .Resolve(r => DataTypeResolvers.GetValue<Ratio>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueSampledData")
                .Resolve(r => DataTypeResolvers.GetValue<SampledData>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueSignature")
                .Resolve(r => DataTypeResolvers.GetValue<Signature>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueTiming")
                .Resolve(r => DataTypeResolvers.GetValue<Timing>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueContactDetail")
                .Resolve(r => DataTypeResolvers.GetValue<ContactDetail>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueContributor")
                .Resolve(r => DataTypeResolvers.GetValue<Contributor>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueDataRequirement")
                .Resolve(r => DataTypeResolvers.GetValue<DataRequirement>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueExpression")
                .Resolve(r => DataTypeResolvers.GetValue<Expression>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueParameterDefinition")
                .Resolve(r => DataTypeResolvers.GetValue<ParameterDefinition>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueRelatedArtifact")
                .Resolve(r => DataTypeResolvers.GetValue<RelatedArtifact>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueTriggerDefinition")
                .Resolve(r => DataTypeResolvers.GetValue<TriggerDefinition>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueUsageContext")
                .Resolve(r => DataTypeResolvers.GetValue<UsageContext>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueDosage")
                .Resolve(r => DataTypeResolvers.GetValue<Dosage>(r.Parent<Task.OutputComponent>().Value));
            descriptor.Field("valueMeta")
                .Resolve(r => DataTypeResolvers.GetValue<Meta>(r.Parent<Task.OutputComponent>().Value));
        }
    }
}

public class TaskReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Task)");
        descriptor.Type<TaskType>();
    }
}