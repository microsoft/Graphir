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