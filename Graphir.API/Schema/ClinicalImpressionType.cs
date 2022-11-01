using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ClinicalImpressionType : ObjectType<ClinicalImpression>
{
    protected override void Configure(IObjectTypeDescriptor<ClinicalImpression> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Id);
        descriptor.Field(c => c.Meta);
        descriptor.Field(c => c.ImplicitRules);
        descriptor.Field(c => c.Language);
        descriptor.Field(c => c.Text);
        descriptor.Field(c => c.Contained);
        descriptor.Field(c => c.Extension);
        descriptor.Field(c => c.ModifierExtension);
        descriptor.Field(c => c.Identifier);
        descriptor.Field(c => c.Status);
        descriptor.Field(c => c.StatusReason);
        descriptor.Field(c => c.Description);
        descriptor.Field(c => c.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(c => c.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field(c => c.Effective).Type<DateTimeType>();
        descriptor.Field(c => c.Date);
        descriptor.Field(c => c.Assessor).Type<ResourceReferenceType<AssessorReferenceType>>();
        descriptor.Field(c => c.Previous).Type<ResourceReferenceType<PreviousReferenceType>>();
        descriptor.Field(c => c.Problem).Type<ResourceReferenceType<ProblemReferenceType>>();
        descriptor.Field(c => c.Investigation).Type<ListType<InvestigationComponentType>>();
        descriptor.Field(c => c.Protocol);
        descriptor.Field(c => c.Summary);
        descriptor.Field(c => c.Finding).Type<ListType<FindingComponentType>>();
        descriptor.Field(c => c.PrognosisCodeableConcept);
        // descriptor.Field(c => c.PrognosisReference).Type<ResourceReferenceType<PrognosisReferenceType>>();
        descriptor.Field(c => c.SupportingInfo).Type<ResourceReferenceType<SupportingInfoReferenceType>>();
        descriptor.Field(c => c.Note);
    }
}

public class FindingComponentType : ObjectType<ClinicalImpression.FindingComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ClinicalImpression.FindingComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.ItemCodeableConcept);
        descriptor.Field(c => c.ItemReference).Type<ResourceReferenceType<ItemReferenceReferenceType>>();
        descriptor.Field(c => c.Basis);
    }
}

public class ItemReferenceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ItemReferenceReference");
        descriptor.Type<ConditionType>();
        /*
        TODO: Add below types here 
        descriptor.Type<ObservationType>();
        descriptor.Type<MediaType>();
        */
    }
}

public class InvestigationComponentType : ObjectType<ClinicalImpression.InvestigationComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ClinicalImpression.InvestigationComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Code);
        // descriptor.Field(c => c.Item).Type<ResourceReferenceType<ItemReferenceType>>();
    }
}

/*
 TODO: Add all the types that are possible to be returned here
public class ItemReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ItemReference");
        descriptor.Description(@"Record of a specific investigation Reference(Observation | QuestionnaireResponse |
                                FamilyMemberHistory | DiagnosticReport | RiskAssessment | ImagingStudy | Media");

        descriptor.Type<ObservationType>();
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<FamilyMemberHistoryType>();
        descriptor.Type<DiagnosticReportType>();
        descriptor.Type<RiskAssessmentType>();
        descriptor.Type<ImagingStudyType>();
        descriptor.Type<ConditionType>();
        descriptor.Type<MediaType>();
    }
}
*/

public class ProblemReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ProblemReference");
        descriptor.Description("Relevant impressions of patient state");
        descriptor.Type<ConditionType>();
        //descriptor.Type<AllergyIntoleranceType>(); TODO: Add support for AllergyIntoleranceType
    }
}

/*
  TODO: Need to add RiskAssessmentType
public class PrognosisReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PrognosisReference");
        descriptor.Description("RiskAssessment expressing likely outcome");
        descriptor.Type<RiskAssessmentType>();
    }
}
*/

public class PreviousReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PreviousReference");
        descriptor.Description("Reference to last assessment");
        descriptor.Type<ClinicalImpressionType>();
    }
}

public class AssessorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("AssessorReference");
        descriptor.Description("The clinician performing the assessment. Reference(Practitioner | PractitionerRole)");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
    }
}
