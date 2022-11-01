using Hl7.Fhir.Model;

using HotChocolate.Types;

using static Hl7.Fhir.Model.CarePlan;

namespace Graphir.API.Schema;

public class CarePlanType : ObjectType<CarePlan>
{
    protected override void Configure(IObjectTypeDescriptor<CarePlan> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<CarePlanBasedOnReferenceType>>>();
        descriptor.Field(x => x.Replaces).Type<ListType<ResourceReferenceType<CarePlanBasedOnReferenceType>>>();
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<CarePlanBasedOnReferenceType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Intent);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Title);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field(x => x.Period).Type<PeriodType>();
        descriptor.Field(x => x.Created);
        descriptor.Field(x => x.Author).Type<ResourceReferenceType<AuthorReferenceType>>();
        descriptor.Field(x => x.Contributor).Type<ListType<ResourceReferenceType<ContributorReferenceType>>>();
       // descriptor.Field(x => x.CareTeam).Type<ListType<ResourceReferenceType<CareTeamTypeReference>>>();
        descriptor.Field(x => x.Addresses).Type<ListType<ResourceReferenceType<ConditionReferenceType>>>();
        descriptor.Field(x => x.SupportingInfo).Type<ListType<ResourceReferenceType<SupportingInfoResourceType>>>();
        // descriptor.Field(x => x.Goal).Type<ListType<ResourceReferenceType<GoalReferenceType>>>();
        descriptor.Field(x => x.Activity).Type<ListType<CarePlanActivityComponentType>>();
        descriptor.Field(x => x.Note).Type<ListType<AnnotationType>>();
    }
}

public class SupportingInfoResourceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SupportingInfoResourceType");
        descriptor.Description("Information considered as part of plan");
        
        descriptor.Type<ResourceType>();
    }
}

public class CarePlanActivityComponentType : ObjectType<ActivityComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ActivityComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.OutcomeCodeableConcept);
        descriptor.Field(x => x.OutcomeReference).Type<ListType<ResourceReferenceType<OutcomeReferenceType>>>();
        descriptor.Field(x => x.Progress);
        descriptor.Field(x => x.Reference).Type<ResourceReferenceType<OutcomeReferenceType>>();
        descriptor.Field(x => x.Detail).Type<CarePlanActivityDetailComponentType>();
    }
}

public class CarePlanActivityDetailComponentType : ObjectType<DetailComponent>
{
    protected override void Configure(IObjectTypeDescriptor<DetailComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.ElementId);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.ReasonCode);
        descriptor.Field(x => x.ReasonReference).Type<ListType<ResourceReferenceType<ReasonReferenceType>>>();
        //descriptor.Field(x => x.Goal).Type<ListType<ResourceReferenceType<GoalReferenceType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.StatusReason);
        // descriptor.Field(x => x.Scheduled).Resolve(
        //     s =>
        //     {
        //         var scheduled = s.Parent<DetailComponent>().Scheduled;
        //         return scheduled.TypeName switch
        //         {
        //             nameof(Period) => (Period)scheduled,
        //             nameof(FhirString) => (FhirString)scheduled,
        //             nameof(Timing) => (Timing)scheduled,
        //             _ => null
        //         };
        //     }
        // );
        descriptor.Field(x => x.Location).Type<ResourceReferenceType<LocationReferenceType>>();
        descriptor.Field(x => x.Performer).Type<ListType<ResourceReferenceType<PerformerReferenceType>>>();
        descriptor.Field(x => x.Kind);
        // descriptor.Field(x => x.Product).Type<ResourceReferenceType<ProductReferenceType>>();
        descriptor.Field(x => x.DailyAmount).Type<QuantityType>();
        descriptor.Field(x => x.Quantity).Type<QuantityType>();
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.InstantiatesCanonical);
        descriptor.Field(x => x.InstantiatesUri);
        descriptor.Field(x => x.KindElement).Type<StringType>();
        descriptor.Field(x => x.DoNotPerform);
    }
}

public class PerformerReferenceType : UnionType
{
     /*
       [References(new string[] {"Practitioner", "PractitionerRole", "Organization", "RelatedPerson", "Patient", "CareTeam", "HealthcareService", "Device"})]
     */
     protected override void Configure(IUnionTypeDescriptor descriptor)
     {
            descriptor.Name("PerformerReferenceType");
            descriptor.Description("Who will be responsible?");

            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<RelatedPersonType>();
            descriptor.Type<PatientType>();
            // descriptor.Type<CareTeamType>(); TODO: Need to implement CareTeamType
            descriptor.Type<HealthcareServiceType>();
            descriptor.Type<DeviceType>();
            
     }
}

public class ReasonReferenceType : UnionType
{
    /*
       [References(new string[] {"Condition", "Observation", "DiagnosticReport", "DocumentReference"})]
     */

    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ReasonReferenceType");
        descriptor.Description("Reason for current status");

        descriptor.Type<ConditionType>();
        /* TODO: Add below types 
         descriptor.Type<ObservationType>();
        descriptor.Type<DiagnosticReportType>();
        descriptor.Type<DocumentReferenceType>();*/
    }
}

public class OutcomeReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("OutcomeReferenceType");
        descriptor.Description("Appointment, Encounter, Procedure, etc.");
        
        descriptor.Type<ResourceType>();
    }
}

public class GoalReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("GoalReferenceType");
        descriptor.Description("Desired outcome of plan");
        //descriptor.Type<GoalType>(); TODO: Add GoalType
    }
}

public class ConditionReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ConditionReferenceType");
        descriptor.Description("Health issues this plan addresses");

        descriptor.Type<ConditionType>();
    }
}

public class CareTeamTypeReference : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CareTeamTypeReference");
        // descriptor.Type<CareTeamType>(); TODO: Need to Implement CareTeamType 
    }
}

public class ContributorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContributorReferenceType");
        descriptor.Description(
            "Who provided the content of the care plan. Reference(Patient|Practitioner|PractitionerRole|Device|RelatedPerson|Organization|CareTeam)");

        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<OrganizationType>();
        // descriptor.Type<CareTeamType>(); TODO: Need to Implement CareTeamType 
    }
}

public class AuthorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("AuthorReferenceType");
        descriptor.Description("Who is the designated responsible party. Reference(Patient|Practitioner|PractitionerRole|Device|RelatedPerson|Organization|CareTeam)");

        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<OrganizationType>();
        // descriptor.Type<CareTeamType>(); TODO: Need to Implement CareTeamType 
    }
}

public class CarePlanBasedOnReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CarePlanBasedOnType");

        descriptor.Type<CarePlanType>();
    }
}