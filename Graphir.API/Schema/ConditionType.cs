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

        descriptor.Field("onsetDateTime").Type<DateTimeType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "dateTime"
                ? (FhirDateTime)parent.Onset
                : null;
        });
        descriptor.Field("onsetAge").Type<AgeType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "Age"
                ? (Age)parent.Onset
                : null;
        });
        descriptor.Field("onsetPeriod").Type<PeriodType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "Period"
                ? (Period)parent.Onset
                : null;
        });
        descriptor.Field("onsetRange").Type<RangeType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "Range"
                ? (Range)parent.Onset
                : null;
        });
        descriptor.Field("onsetString").Type<StringType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "string"
                ? parent.Onset.ToString()
                : null;
        });

        descriptor.Field("abatementDateTime").Type<DateTimeType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "dateTime"
                ? (FhirDateTime)parent.Onset
                : null;
        });
        descriptor.Field("abatementAge").Type<AgeType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "Age"
                ? (Age)parent.Onset
                : null;
        });
        descriptor.Field("abatementPeriod").Type<PeriodType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "Period"
                ? (Period)parent.Onset
                : null;
        });
        descriptor.Field("abatementRange").Type<RangeType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "Range"
                ? (Range)parent.Onset
                : null;
        });
        descriptor.Field("abatementString").Type<StringType>().Resolve(r =>
        {
            var parent = r.Parent<Condition>();
            return parent.Onset is not null && parent.Onset.TypeName == "string"
                ? parent.Onset.ToString()
                : null;
        });

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
