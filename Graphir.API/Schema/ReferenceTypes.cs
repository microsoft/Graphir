using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ManagingOrganizationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ManagingOrganizationReference");
        descriptor.Type<OrganizationType>();
    }
}

public class SubjectReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SubjectReference");
        descriptor.Description("Reference(Patient | Group)");
        descriptor.Type<PatientType>();
        descriptor.Type<GroupType>();
    }
}

public class EncounterReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterReference");
        descriptor.Description("Reference(Encounter)");
        descriptor.Type<EncounterType>();
    }
}

public class CareTeamReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CareTeamReferenceType");
        descriptor.Description("Reference(CareTeam)");
        descriptor.Type<CareTeamType>();
    }
}

public class ObservationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationReferenceType");
        descriptor.Description("Reference(Observation)");
        descriptor.Type<ObservationType>();
    }
}

public class MedicationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationReference");
        descriptor.Description("Reference(Medication)");
        descriptor.Type<MedicationType>();
    }
}

public class AnyReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Any)");
        descriptor.Type<ResourceType>();
    }
}

public class SpecimenReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Specimen)");
        descriptor.Type<SpecimenType>();
    }
}

public class ProvenanceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Provenance)");
        descriptor.Type<ProvenanceType>();
    }
}

public class LocationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Location)");
        descriptor.Type<LocationType>();

    }
}

public class InsuranceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("InsuranceReference");
        descriptor.Type<CoverageType>();
        descriptor.Type<ClaimResponseType>();
    }
}

public class EpisodeOfCareReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EncounterEpisodeOfCareType");
        descriptor.Description("The list of resources that describe the parts of the episode of care that identify which resources are to be updated when the episode is to be managed.");
        descriptor.Type<EpisodeOfCareType>();
    }
}

public class ServiceRequestReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(ServiceRequest)");
        descriptor.Type<ServiceRequestType>();
    }
}

public class AccountReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Account)");
        descriptor.Type<AccountType>();
    }
}

public class AppointmentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Appointment)");
        descriptor.Type<AppointmentType>();
    }
}

public class PatientReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Patient)");
        descriptor.Type<PatientType>();
    }
}

public class EndpointReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Endpoint)");
        descriptor.Type<EndpointType>();
    }
}

public class PractitionerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Practitioner)");
        descriptor.Type<PractitionerType>();
    }
}

public class OrganizationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Organization)");
        descriptor.Type<OrganizationType>();
    }
}

public class HealthcareServiceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(HealthcareService)");
        descriptor.Type<HealthcareServiceType>();
    }
}

public class DeviceDefinitionReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(DeviceDefinition)");
        descriptor.Type<DeviceDefinitionType>();
    }
}

public class CoverageReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Coverage)");
        descriptor.Type<CoverageType>();
    }
}

public class ConditionReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Condition)");
        descriptor.Type<ConditionType>();
    }
}