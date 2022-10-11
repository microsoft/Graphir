using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
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
            descriptor.Field(c => c.Subject).Type<ResourceReferenceType<ConditionSubjectReferenceType>>();
            descriptor.Field(c => c.Encounter).Type<ResourceReferenceType<ConditionEncounterReferenceType>>();
            descriptor.Field(c => c.RecordedDate);
            descriptor.Field(c => c.Recorder).Type<ResourceReferenceType<ConditionRecorderReferenceType>>();
            descriptor.Field(c => c.Asserter).Type<ResourceReferenceType<ConditionAsserterReferenceType>>();
            descriptor.Field(c => c.Stage).Type<ConditionStageType>();
            descriptor.Field(c => c.Evidence).Type<ConditionEvidenceType>();
            descriptor.Field(c => c.Note);

            descriptor.Field("onsetDateTime").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "dateTime")
                    ? (FhirDateTime)parent.Onset
                    : null;
            });
            descriptor.Field("onsetAge").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "Age")
                    ? (Age)parent.Onset
                    : null;
            });
            descriptor.Field("onsetPeriod").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "Period")
                    ? (Period)parent.Onset
                    : null;
            });
            descriptor.Field("onsetRange").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "Range")
                    ? (Range)parent.Onset
                    : null;
            });
            descriptor.Field("onsetString").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "string")
                    ? parent.Onset.ToString()
                    : null;
            });

            descriptor.Field(c => c.Abatement); //dataType
            descriptor.Field("abatementDateTime").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "dateTime")
                    ? (FhirDateTime)parent.Onset
                    : null;
            });
            descriptor.Field("abatementAge").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "Age")
                    ? (Age)parent.Onset
                    : null;
            });
            descriptor.Field("abatementPeriod").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "Period")
                    ? (Period)parent.Onset
                    : null;
            });
            descriptor.Field("abatementRange").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "Range")
                    ? (Range)parent.Onset
                    : null;
            });
            descriptor.Field("abatementString").Resolve(r =>
            {
                var parent = r.Parent<Condition>();
                return (parent.Onset is not null && parent.Onset.TypeName == "string")
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
            descriptor.Field(c => c.Detail); //codeable ref
        }
    }

    public class ConditionSubjectReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ConditionSubjectReference");
            descriptor.Description("Reference(Patient | Group)");
            descriptor.Type<PatientType>();
            descriptor.Type<GroupType>();
        }
    }

    public class ConditionEncounterReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ConditionEncounterReference");
            descriptor.Description("Reference(Encounter)");
            descriptor.Type<EncounterType>();
        }
    }

    public class ConditionRecorderReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ConditionRecorderReference");
            descriptor.Name("Reference(Practitioner | PractitionerRole | Patient | RelatedPerson)");
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

    #region QueryExtentions
    public class ConditionQuery : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field("Condition")
                .Type<ConditionType>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<Condition>>(r => r.GetResource(default!, default!));

            descriptor.Field("ConditionList")
                .Type<ListType<ConditionType>>()
                .ResolveWith<ResourceResolvers<Condition>>(r => r.GetResources(default!));
        }
    }

    #endregion
}
