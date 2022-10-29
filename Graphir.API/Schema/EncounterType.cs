using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class EncounterType : ObjectType<Encounter>
{
    /*
type EncounterStatusHistory {
  id: ID
  extension: [Extension]
  modifierExtension: [Extension]
  status: code  _status: ElementBase
  period: Period!
}

type EncounterClassHistory {
  id: ID
  extension: [Extension]
  modifierExtension: [Extension]
  class: Coding!
  period: Period!
}

type EncounterParticipant {
  id: ID
  extension: [Extension]
  modifierExtension: [Extension]
  type: [CodeableConcept]
  period: Period
  actor: Reference
}

type EncounterDiagnosis {
  id: ID
  extension: [Extension]
  modifierExtension: [Extension]
  condition: Reference!
  use: CodeableConcept
  rank: positiveInt  _rank: ElementBase
}

type EncounterHospitalization {
  id: ID
  extension: [Extension]
  modifierExtension: [Extension]
  preAdmissionIdentifier: Identifier
  origin: Reference
  admitSource: CodeableConcept
  reAdmission: CodeableConcept
  dietPreference: [CodeableConcept]
  specialCourtesy: [CodeableConcept]
  specialArrangement: [CodeableConcept]
  destination: Reference
  dischargeDisposition: CodeableConcept
}

type EncounterLocation {
  id: ID
  extension: [Extension]
  modifierExtension: [Extension]
  location: Reference!
  status: code  _status: ElementBase
  physicalType: CodeableConcept
  period: Period
}

input EncounterInput {
  id: ID
  meta: MetaInput
  implicitRules: uri  _implicitRules: ElementBaseInput
  language: code  _language: ElementBaseInput
  text: NarrativeInput
  contained: [ResourceInput]
  extension: [ExtensionInput]
  modifierExtension: [ExtensionInput]
  identifier: [IdentifierInput]
  status: code  _status: ElementBaseInput
  statusHistory: [EncounterStatusHistoryInput]
  class: CodingInput!
  classHistory: [EncounterClassHistoryInput]
  type: [CodeableConceptInput]
  serviceType: CodeableConceptInput
  priority: CodeableConceptInput
  subject: ReferenceInput
  subjectStatus: CodeableConceptInput
  episodeOfCare: [ReferenceInput]
  basedOn: [ReferenceInput]
  participant: [EncounterParticipantInput]
  appointment: [ReferenceInput]
  period: PeriodInput
  length: DurationInput
  reason: [CodeableReferenceInput]
  diagnosis: [EncounterDiagnosisInput]
  account: [ReferenceInput]
  hospitalization: EncounterHospitalizationInput
  location: [EncounterLocationInput]
  serviceProvider: ReferenceInput
  partOf: ReferenceInput
}

input EncounterStatusHistoryInput {
  id: ID
  extension: [ExtensionInput]
  modifierExtension: [ExtensionInput]
  status: code  _status: ElementBaseInput
  period: PeriodInput!
}

input EncounterClassHistoryInput {
  id: ID
  extension: [ExtensionInput]
  modifierExtension: [ExtensionInput]
  class: CodingInput!
  period: PeriodInput!
}

input EncounterParticipantInput {
  id: ID
  extension: [ExtensionInput]
  modifierExtension: [ExtensionInput]
  type: [CodeableConceptInput]
  period: PeriodInput
  actor: ReferenceInput
}

input EncounterDiagnosisInput {
  id: ID
  extension: [ExtensionInput]
  modifierExtension: [ExtensionInput]
  condition: ReferenceInput!
  use: CodeableConceptInput
  rank: positiveInt  _rank: ElementBaseInput
}

input EncounterHospitalizationInput {
  id: ID
  extension: [ExtensionInput]
  modifierExtension: [ExtensionInput]
  preAdmissionIdentifier: IdentifierInput
  origin: ReferenceInput
  admitSource: CodeableConceptInput
  reAdmission: CodeableConceptInput
  dietPreference: [CodeableConceptInput]
  specialCourtesy: [CodeableConceptInput]
  specialArrangement: [CodeableConceptInput]
  destination: ReferenceInput
  dischargeDisposition: CodeableConceptInput
}

input EncounterLocationInput {
  id: ID
  extension: [ExtensionInput]
  modifierExtension: [ExtensionInput]
  location: ReferenceInput!
  status: code  _status: ElementBaseInput
  physicalType: CodeableConceptInput
  period: PeriodInput
}

type EncounterReadType {
  Encounter(id: ID!): Encounter
}

type EncounterListType {
  EncounterList(_filter: String
    account: [reference]
    appointment: [reference]
    based_on: [reference]
    class: [token]
    date: [date]
    diagnosis: [reference]
    episode_of_care: [reference]
    identifier: [token]
    length: [quantity]
    location: [reference]
    location_period: [date]
    part_of: [reference]
    participant: [reference]
    participant_type: [token]
    patient: [reference]
    practitioner: [reference]
    reason_code: [token]
    reason_reference: [reference]
    service_provider: [reference]
    special_arrangement: [token]
    status: [token]
    subject: [reference]
    subject_status: [token]
    type: [token]
    _text: [special]
    _content: [special]
    _id: [token]
    _lastUpdated: [date]
    _list: [special]
    _profile: [reference]
    _query: [special]
    _security: [token]
    _source: [uri]
    _tag: [token]
    _sort: String
    _count: Int
    _cursor: String): [Encounter]
}

type EncounterConnectionType {
  EncounterConnection(_filter: String
    account: [reference]
    appointment: [reference]
    based_on: [reference]
    class: [token]
    date: [date]
    diagnosis: [reference]
    episode_of_care: [reference]
    identifier: [token]
    length: [quantity]
    location: [reference]
    location_period: [date]
    part_of: [reference]
    participant: [reference]
    participant_type: [token]
    patient: [reference]
    practitioner: [reference]
    reason_code: [token]
    reason_reference: [reference]
    service_provider: [reference]
    special_arrangement: [token]
    status: [token]
    subject: [reference]
    subject_status: [token]
    type: [token]
    _text: [special]
    _content: [special]
    _id: [token]
    _lastUpdated: [date]
    _list: [special]
    _profile: [reference]
    _query: [special]
    _security: [token]
    _source: [uri]
    _tag: [token]
    _sort: String
    _count: Int
    _cursor: String): EncounterConnection
}
*/
    
    // TODO: finish Encounter
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
        descriptor.Field(e => e.StatusHistory).Type<ListType<EncounterStatusHistoryComponentType>>();
        descriptor.Field(e => e.Class).Type<CodingType>();
        descriptor.Field(e => e.ClassHistory).Type<ListType<ClassHistoryComponentType>>();
        descriptor.Field(e => e.Type);
        descriptor.Field(e => e.ServiceType);
        descriptor.Field(e => e.Priority);
        descriptor.Field(e => e.Subject).Type<ResourceReferenceType<EncounterSubjectType>>();
        // descriptor.Field(e => e.EpisodeOfCare).Type<ListType<ResourceReferenceType<EncounterEpisodeOfCareType>>>();
        descriptor.Field(e => e.BasedOn).Type<ListType<ResourceReferenceType<EncounterBasedOnType>>>();
        // descriptor.Field(e => e.Participant).Type<ListType<EncounterParticipantComponentType>>();
        descriptor.Field(e => e.Appointment).Type<ListType<ResourceReferenceType<EncounterAppointmentType>>>();
        descriptor.Field(e => e.Period).Type<PeriodType>();
        descriptor.Field(e => e.Length).Type<DurationType>();
        descriptor.Field(e => e.ReasonReference).Type<ListType<ResourceReferenceType<EncounterReasonReferenceType>>>();
        descriptor.Field(e => e.ReasonCode);
        descriptor.Field(e => e.ResourceBase);
        descriptor.Field(e => e.Diagnosis).Type<ListType<EncounterDiagnosisComponentType>>();
        descriptor.Field(e => e.Account).Type<ListType<EncounterAccountType>>();
        descriptor.Field(e => e.Hospitalization).Type<HospitalizationComponentType>();
        descriptor.Field(e => e.Location).Type<ListType<EncounterLocationComponentType>>();
        descriptor.Field(e => e.ServiceProvider).Type<ResourceReferenceType<EncounterServiceProviderType>>();
        descriptor.Field(e => e.PartOf).Type<ResourceReferenceType<EncounterPartOfType>>();
    }
}

public class EncounterAccountType : ObjectType<Account>
{
  protected override void Configure(IObjectTypeDescriptor<Account> descriptor)
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
    descriptor.Field(e => e.Type);
    descriptor.Field(e => e.Subject).Type<ResourceReferenceType<EncounterSubjectType>>();
    descriptor.Field(e => e.Guarantor).Type<ListType<EncounterGuarantorComponentType>>();
  }
}

public class EncounterGuarantorComponentType : ObjectType<Account.GuarantorComponent>
{
  protected override void Configure(IObjectTypeDescriptor<Account.GuarantorComponent> descriptor)
  {
    descriptor.BindFieldsExplicitly();
    descriptor.Field(e => e.Extension);
    descriptor.Field(e => e.ModifierExtension);
    descriptor.Field(e => e.Party).Type<ResourceReferenceType<EncounterPartyType>>();
    descriptor.Field(e => e.OnHold);
    descriptor.Field(e => e.Period).Type<PeriodType>();
  }
}

public class EncounterPartyType : UnionType
{
  protected override void Configure(IUnionTypeDescriptor descriptor)
  {
    descriptor.Name("EncounterParty");
    descriptor.Description("The party(s) that are responsible for covering the payment of this account, and what order should they be applied to the account.");
    descriptor.Type<PatientType>();
    descriptor.Type<RelatedPersonType>();
    descriptor.Type<OrganizationType>();
  }
}

public class EncounterDiagnosisComponentType : ObjectType<Encounter.DiagnosisComponent>
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
    // descriptor.Type<ProcedureType>(); TODO: add ProcedureType
  }
}

public class EncounterReasonReferenceType : UnionType
{
  protected override void Configure(IUnionTypeDescriptor descriptor)
  {
    descriptor.Name("EncounterReasonReferenceType");
    descriptor.Description("The list of possible types for the discriminator Encounter.reasonReference Condition | Procedure | Observation | ImmunizationRecommendation");
    descriptor.Type<ConditionType>();
    /*
    TODO: Add following types
    descriptor.Type<ProcedureType>();
    descriptor.Type<ObservationType>();
    descriptor.Type<ImmunizationRecommendationType>();
    */

  }
}

public class EncounterAppointmentType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterAppointment");
        descriptor.Description("Appointment that scheduled this encounter");
        descriptor.Type<AppointmentType>();
    }
}

public class EncounterStatusHistoryComponentType : ObjectType<Encounter.StatusHistoryComponent>
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

public class EncounterParticipantComponentType : ObjectType<Encounter.ParticipantComponent>
{
  protected override void Configure(IObjectTypeDescriptor<Encounter.ParticipantComponent> descriptor)
  {
    descriptor.BindFieldsExplicitly();
    descriptor.Field(e => e.Type);
    descriptor.Field(e => e.Period);
    descriptor.Field(e => e.Individual).Type<ResourceReferenceType<EncounterParticipantComponentIndividualType>>();
  }
}

public class EncounterParticipantComponentIndividualType : UnionType
{
  protected override void Configure(IUnionTypeDescriptor descriptor)
  {
    descriptor.Name("EncounterParticipantComponentIndividual");
    descriptor.Description("The individual who is participating in the encounter.");
    descriptor.Type<PractitionerType>();
    descriptor.Type<PractitionerRoleType>();
    descriptor.Type<RelatedPersonType>();
  }
}

public class EncounterBasedOnType : UnionType
{
  protected override void Configure(IUnionTypeDescriptor descriptor)
  {
    descriptor.Name("EncounterBasedOn");
    descriptor.Description("The patient or group present at the encounter.");
    descriptor.Type<ServiceRequestType>();
  }
}

public class EncounterEpisodeOfCareType : UnionType
{
  protected override void Configure(IUnionTypeDescriptor descriptor)
  {
    descriptor.Name("EncounterEpisodeOfCareType");
    descriptor.Description("The list of resources that describe the parts of the episode of care that identify which resources are to be updated when the episode is to be managed.");
    // descriptor.Type<EpisodeOfCareType>(); TODO: add EpisodeOfCare
  }
}

public class EncounterSubjectType : UnionType
{
  protected override void Configure(IUnionTypeDescriptor descriptor)
  {
    descriptor.Name("EncounterSubject");
    descriptor.Description("The patient or group present at the encounter.");
    descriptor.Type<PatientType>();
    descriptor.Type<GroupType>();
  }
}

public class ClassHistoryComponentType : ObjectType<Encounter.ClassHistoryComponent>
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

public class HospitalizationComponentType : ObjectType<Encounter.HospitalizationComponent>
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
