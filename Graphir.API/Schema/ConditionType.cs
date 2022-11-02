using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ConditionType : ObjectType<Condition>
{
    protected override void Configure(IObjectTypeDescriptor<Condition> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Id);
        descriptor.Field(c => c.Meta);
        descriptor.Field(c => c.Language);
        descriptor.Field(c => c.Text);
        descriptor.Field(c => c.Extension);
        descriptor.Field(c => c.ModifierExtension);
        descriptor.Field(c => c.Identifier);
        descriptor.Field(c => c.ClinicalStatus);
        descriptor.Field(c => c.VerificationStatus);
        descriptor.Field(c => c.Category);
        descriptor.Field(c => c.Severity);
        descriptor.Field(c => c.Code);
        descriptor.Field(c => c.BodySite);
        descriptor.Field(c => c.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(c => c.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field(c => c.RecordedDate);
        descriptor.Field(c => c.Recorder).Type<ResourceReferenceType<ConditionRecorderReferenceType>>();
        descriptor.Field(c => c.Asserter).Type<ResourceReferenceType<ConditionAsserterReferenceType>>();
        descriptor.Field(c => c.Stage).Type<ListType<ConditionStageType>>();
        descriptor.Field(c => c.Evidence).Type<ListType<ConditionEvidenceType>>();
        descriptor.Field(c => c.Note);

        descriptor.Field("onsetDateTime").Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Condition>().Onset));
        descriptor.Field("onsetAge").Resolve(r => DataTypeResolvers.GetValue<Age>(r.Parent<Condition>().Onset));
        descriptor.Field("onsetPeriod").Resolve(r => DataTypeResolvers.GetValue<Period>(r.Parent<Condition>().Onset));
        descriptor.Field("onsetRange").Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<Condition>().Onset));
        descriptor.Field("onsetString").Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<Condition>().Onset));

        descriptor.Field("abatementDateTime").Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Condition>().Abatement));
        descriptor.Field("abatementAge").Resolve(r => DataTypeResolvers.GetValue<Age>(r.Parent<Condition>().Abatement));
        descriptor.Field("abatementPeriod").Resolve(r => DataTypeResolvers.GetValue<Period>(r.Parent<Condition>().Abatement));
        descriptor.Field("abatementRange").Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<Condition>().Abatement));
        descriptor.Field("abatementString").Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<Condition>().Abatement));
    }
}

public class ConditionStageType : ObjectType<Condition.StageComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Condition.StageComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Extension);
        descriptor.Field(c => c.ModifierExtension);
        descriptor.Field(c => c.Summary);
        descriptor.Field(c => c.Assessment).Type<CodeableReferenceType<ConditionStageAssessmentReferenceType>>();
        descriptor.Field(c => c.Type);
    }
}

public class ConditionEvidenceType : ObjectType<Condition.EvidenceComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Condition.EvidenceComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Extension);
        descriptor.Field(c => c.ModifierExtension);
        descriptor.Field(c => c.Code);
        descriptor.Field(c => c.Detail).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
    }
}

public class ConditionRecorderReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConditionRecorderReference");
        descriptor.Description("Reference(Practitioner | PractitionerRole | Patient | RelatedPerson)");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class ConditionAsserterReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConditionAsserterReference");
        descriptor.Description("Reference(Practitioner | PractitionerRole | Patient | RelatedPerson)");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class ConditionStageAssessmentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConditionStageAssessmentReference");
        descriptor.Description("Reference(ClinicalImpression | DiagnosticReport | Observation)");
        descriptor.Type<ClinicalImpressionType>();
        descriptor.Type<DiagnosticReportType>();
        descriptor.Type<ObservationType>();
    }
}
