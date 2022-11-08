using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class EncounterType : ObjectType<Encounter>
{
    protected override void Configure(IObjectTypeDescriptor<Encounter> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.Id);
        descriptor.Field(e => e.Meta);
        descriptor.Field(e => e.ImplicitRules);
        descriptor.Field(e => e.Language);
        descriptor.Field(e => e.Text);
        descriptor.Field(e => e.Contained);
        descriptor.Field(e => e.Extension);
        descriptor.Field(e => e.ModifierExtension);
        descriptor.Field(e => e.Identifier);
        descriptor.Field(e => e.Status);
        descriptor.Field(e => e.StatusHistory).Type<ListType<EncounterStatusHistoryType>>();
        descriptor.Field(e => e.Class);
        descriptor.Field(e => e.ClassHistory).Type<ListType<EncounterClassHistoryType>>();
        descriptor.Field(e => e.Type);
        descriptor.Field(e => e.ServiceType);
        descriptor.Field(e => e.Priority);
        descriptor.Field(e => e.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(e => e.EpisodeOfCare).Type<ListType<ResourceReferenceType<EpisodeOfCareReferenceType>>>();
        descriptor.Field(e => e.BasedOn).Type<ListType<ResourceReferenceType<ServiceRequestReferenceType>>>();
        descriptor.Field(e => e.Participant).Type<ListType<EncounterParticipantType>>();
        descriptor.Field(e => e.Appointment).Type<ListType<ResourceReferenceType<AppointmentReferenceType>>>();
        descriptor.Field(e => e.Period).Type<PeriodType>();
        descriptor.Field(e => e.Length).Type<DurationType>();
        descriptor.Field(e => e.ReasonReference).Type<ListType<ResourceReferenceType<EncounterReasonReferenceType>>>();
        descriptor.Field(e => e.ReasonCode);
        descriptor.Field(e => e.ResourceBase);
        descriptor.Field(e => e.Diagnosis).Type<ListType<EncounterDiagnosisType>>();
        descriptor.Field(e => e.Account).Type<ListType<ResourceReferenceType<AccountReferenceType>>>();
        descriptor.Field(e => e.Hospitalization).Type<EncounterHospitalizationType>();
        descriptor.Field(e => e.Location).Type<ListType<EncounterLocationComponentType>>();
        descriptor.Field(e => e.ServiceProvider).Type<ResourceReferenceType<EncounterServiceProviderType>>();
        descriptor.Field(e => e.PartOf).Type<ResourceReferenceType<EncounterPartOfType>>();
    }
}

public class EncounterDiagnosisType : ObjectType<Encounter.DiagnosisComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Encounter.DiagnosisComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.ElementId);
        descriptor.Field(e => e.Extension);
        descriptor.Field(e => e.ModifierExtension);
        descriptor.Field(e => e.Condition).Type<ResourceReferenceType<EncounterDiagnosisComponentConditionType>>();
        descriptor.Field(e => e.Rank);
        descriptor.Field(e => e.Use);
        descriptor.Field(e => e.TypeName);
    }
}

public class EncounterDiagnosisComponentConditionType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterDiagnosisComponentCondition");
        descriptor.Description("The condition that is the reason the encounter takes place");
        descriptor.Type<ConditionType>();
        descriptor.Type<ProcedureType>();
    }
}

public class EncounterReasonReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterReasonReference");
        descriptor.Description("Reference(Condition | Procedure | Observation | ImmunizationRecommendation)");
        descriptor.Type<ConditionType>();
        descriptor.Type<ProcedureType>();
        descriptor.Type<ObservationType>();
        descriptor.Type<ImmunizationRecommendationType>();
    }
}

public class EncounterStatusHistoryType : ObjectType<Encounter.StatusHistoryComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Encounter.StatusHistoryComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.Status);
        descriptor.Field(e => e.Period);
    }
}

public class EncounterPartOfType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterPartOfType");
        descriptor.Description("Another Encounter this encounter is part of");
        descriptor.Type<EncounterType>();
    }
}

public class EncounterServiceProviderType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterServiceProvider");
        descriptor.Description("The organization (facility) responsible for this encounter.");
        descriptor.Type<OrganizationType>();
    }
}

public class EncounterLocationComponentType : ObjectType<Encounter.LocationComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Encounter.LocationComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.ElementId);
        descriptor.Field(e => e.Extension);
        descriptor.Field(e => e.ModifierExtension);
        descriptor.Field(e => e.Location).Type<ResourceReferenceType<EncounterLocationComponentLocationType>>();
        descriptor.Field(e => e.Status);
        descriptor.Field(e => e.PhysicalType);
        descriptor.Field(e => e.Period);
    }
}

public class EncounterLocationComponentLocationType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterLocationComponentLocation");
        descriptor.Description("The location where the encounter takes place");
        descriptor.Type<LocationType>();
    }
}

public class EncounterParticipantType : ObjectType<Encounter.ParticipantComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Encounter.ParticipantComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Name("EncounterParticipantComponent");
        descriptor.Description("List of participants involved in the encounter");
        descriptor.Field(e => e.Type);
        descriptor.Field(e => e.Period);
        descriptor.Field(e => e.Individual).Type<ResourceReferenceType<EncounterParticipantIndividualReferenceType>>();
    }
}

public class EncounterParticipantIndividualReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterParticipantIndividualReference");
        descriptor.Description("The individual who is participating in the encounter.");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class EncounterClassHistoryType : ObjectType<Encounter.ClassHistoryComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Encounter.ClassHistoryComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.ElementId);
        descriptor.Field(e => e.Extension);
        descriptor.Field(e => e.ModifierExtension);
        descriptor.Field(e => e.Class);
        descriptor.Field(e => e.Period);
    }
}

public class EncounterHospitalizationType : ObjectType<Encounter.HospitalizationComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Encounter.HospitalizationComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(e => e.ElementId);
        descriptor.Field(e => e.Extension);
        descriptor.Field(e => e.ModifierExtension);
        descriptor.Field(e => e.PreAdmissionIdentifier);
        descriptor.Field(e => e.Origin);
        descriptor.Field(e => e.AdmitSource);
        descriptor.Field(e => e.ReAdmission);
        descriptor.Field(e => e.DietPreference);
        descriptor.Field(e => e.SpecialCourtesy);
        descriptor.Field(e => e.SpecialArrangement);
        descriptor.Field(e => e.Destination);
        descriptor.Field(e => e.DischargeDisposition);
    }
}