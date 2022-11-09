using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ClaimType : ObjectType<Claim>
{
    // TODO: finish ClaimType
    protected override void Configure(IObjectTypeDescriptor<Claim> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.VersionId);
        descriptor.Field(x => x.HasVersionId);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.SubType);
        descriptor.Field(x => x.Use);
        descriptor.Field(x => x.Patient).Type<ResourceReferenceType<ClaimPatientReferenceType>>();
        descriptor.Field(x => x.Created);
        descriptor.Field(x => x.Insurer).Type<ResourceReferenceType<ClaimInsurerReferenceType>>();
        descriptor.Field(x => x.BillablePeriod);
        descriptor.Field(x => x.Enterer).Type<ResourceReferenceType<ClaimEntererReferenceType>>();
        descriptor.Field(x => x.Provider).Type<ResourceReferenceType<ClaimProviderReferenceType>>();
        descriptor.Field(x => x.Referral).Type<ResourceReferenceType<ClaimReferralReferenceType>>();
        descriptor.Field(x => x.Facility).Type<ResourceReferenceType<ClaimFacilityReferenceType>>();
        descriptor.Field(x => x.CareTeam).Type<ListType<ClaimCareTeamComponentType>>();
        descriptor.Field(x => x.Payee).Type<ClaimPayeeComponentType>();
        descriptor.Field(x => x.Diagnosis).Type<ListType<ClaimDiagnosisComponentType>>();
        descriptor.Field(x => x.Procedure).Type<ListType<ClaimProcedureComponentType>>();
        descriptor.Field(x => x.Insurance).Type<ListType<ClaimInsuranceComponentType>>();
        descriptor.Field(x => x.Accident).Type<ClaimAccidentComponentType>();
        descriptor.Field(x => x.Item).Type<ListType<ClaimItemComponentType>>();
        descriptor.Field(x => x.Total);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.FundsReserve);
        descriptor.Field(x => x.OriginalPrescription)
            .Type<ResourceReferenceType<ClaimOriginalPrescriptionReferenceType>>();
        descriptor.Field(x => x.Prescription).Type<ResourceReferenceType<ClaimPrescriptionReferenceType>>();
        descriptor.Field(x => x.TypeName);
    }
}

public class ClaimPrescriptionReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimPrescriptionReference");

        descriptor.Type<DeviceRequestType>();
        descriptor.Type<MedicationRequestType>();
        // descriptor.Type<VisionPrescriptionType>(); TODO: VisionPrescriptionType
    }
}

public class ClaimOriginalPrescriptionReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimOriginalPrescriptionReference");

        descriptor.Type<DeviceRequestType>();
        descriptor.Type<MedicationRequestType>();
        //descriptor.Type<VisionPrescriptionType>(); // TODO: VisionPrescriptionType
    }
}

public class ClaimItemComponentType : ObjectType<Claim.ItemComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.ItemComponent> descriptor)
    {
        descriptor.Name("ClaimItemComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.BodySite);
        descriptor.Field(x => x.CareTeamSequence);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Detail).Type<ListType<ClaimDetailComponentType>>();
        descriptor.Field(x => x.DiagnosisSequence);
        descriptor.Field(x => x.Encounter).Type<ListType<ResourceReferenceType<ClaimItemEncounterReferenceType>>>();
        descriptor.Field(x => x.Factor);
        descriptor.Field(x => x.InformationSequence);

        descriptor.Field("locationAddress")
            .Resolve(x => DataTypeResolvers.GetAddressValue(x.Parent<Claim.ItemComponent>().Location));

        descriptor.Field("locationCodeableConcept")
            .Resolve(x => DataTypeResolvers.GetCodeableConceptValue(x.Parent<Claim.ItemComponent>().Location));

        descriptor.Field("locationResourceReference")
            .Resolve(x => DataTypeResolvers.GetReferenceValue(x.Parent<Claim.ItemComponent>().Location))
            .Type<ResourceReferenceType<ClaimItemLocationResourceReferenceType>>();

        descriptor.Field(x => x.Modifier);
        descriptor.Field(x => x.Net);
        descriptor.Field(x => x.ProcedureSequence);
        descriptor.Field(x => x.ProductOrService);
        descriptor.Field(x => x.ProgramCode);
        descriptor.Field(x => x.Quantity);
        descriptor.Field(x => x.Revenue);
        descriptor.Field(x => x.Sequence);

        descriptor.Field("servicedDate")
            .Resolve(x => DataTypeResolvers.GetDateValue(x.Parent<Claim.ItemComponent>().Serviced));

        descriptor.Field("servicedPeriod")
            .Resolve(x => DataTypeResolvers.GetPeriodValue(x.Parent<Claim.ItemComponent>().Serviced));

        descriptor.Field(x => x.SubSite);
        descriptor.Field(x => x.Udi).Type<ResourceReferenceType<ClaimItemUdiReferenceType>>();
        descriptor.Field(x => x.UnitPrice);
    }
}

public class ClaimItemLocationResourceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimItemLocationResourceReference");
        descriptor.Type<LocationType>();
    }
}

public class ClaimItemEncounterReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimItemEncounterReference");
        descriptor.Type<EncounterType>();
    }
}

public class ClaimItemUdiReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimItemUdiReference");
        descriptor.Type<DeviceType>();
    }
}

public class ClaimDetailComponentType : ObjectType<Claim.DetailComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.DetailComponent> descriptor)
    {
        descriptor.Name("ClaimDetailComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Factor);
        descriptor.Field(x => x.Modifier);

        descriptor.Field(x => x.Net);
        descriptor.Field(x => x.ProductOrService);
        descriptor.Field(x => x.ProgramCode);
        descriptor.Field(x => x.Quantity);
        descriptor.Field(x => x.Revenue);
        descriptor.Field(x => x.Sequence);
        descriptor.Field(x => x.SubDetail).Type<ListType<ClaimSubDetailComponentType>>();
        descriptor.Field(x => x.Udi).Type<ResourceReferenceType<ClaimDetailUdiReferenceType>>();
        descriptor.Field(x => x.UnitPrice);
    }
}

public class ClaimSubDetailComponentType : ObjectType<Claim.SubDetailComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.SubDetailComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Factor);
        descriptor.Field(x => x.Modifier);
        descriptor.Field(x => x.Net);
        descriptor.Field(x => x.ProductOrService);
        descriptor.Field(x => x.ProgramCode);
        descriptor.Field(x => x.Quantity);
        descriptor.Field(x => x.Revenue);
        descriptor.Field(x => x.Sequence);
        descriptor.Field(x => x.Udi).Type<ListType<ResourceReferenceType<ClaimSubDetailUdiReferenceType>>>();
        descriptor.Field(x => x.UnitPrice);
    }
}

public class ClaimSubDetailUdiReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimSubDetailUdiReference");
        descriptor.Type<DeviceType>();
    }
}

public class ClaimDetailUdiReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimDetailUdiReference");
        descriptor.Type<DeviceType>();
    }
}

public class ClaimAccidentComponentType : ObjectType<Claim.AccidentComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.AccidentComponent> descriptor)
    {
        descriptor.Name("ClaimAccidentComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Date);
        descriptor.Field("locationAddress").Resolve(x =>
            DataTypeResolvers.GetAddressValue(x.Parent<Claim.AccidentComponent>().Location));
        descriptor.Field("locationReference").Resolve(x =>
                DataTypeResolvers.GetReferenceValue(x.Parent<Claim.AccidentComponent>().Location))
            .Type<ResourceReferenceType<ClaimAccidentComponentLocationReferenceType>>();
        descriptor.Field(x => x.Type);
    }
}

public class ClaimAccidentComponentLocationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimAccidentComponentLocationReference");
        descriptor.Type<LocationType>();
    }
}

public class ClaimInsuranceComponentType : ObjectType<Claim.InsuranceComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.InsuranceComponent> descriptor)
    {
        descriptor.Name("ClaimInsuranceComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.BusinessArrangement);
        descriptor.Field(x => x.ClaimResponse).Type<ResourceReferenceType<ClaimInsuranceComponentClaimResponseType>>();
        descriptor.Field(x => x.Coverage).Type<ResourceReferenceType<ClaimInsuranceComponentCoverageType>>();
        descriptor.Field(x => x.Focal);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.PreAuthRef);
        descriptor.Field(x => x.Sequence);
    }
}

public class ClaimInsuranceComponentCoverageType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimInsuranceComponentCoverage");
        descriptor.Type<CoverageType>();
    }
}

public class ClaimInsuranceComponentClaimResponseType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimInsuranceComponentClaimResponseType");
        descriptor.Type<ClaimResponseType>();
    }
}

public class ClaimProcedureComponentType : ObjectType<Claim.ProcedureComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.ProcedureComponent> descriptor)
    {
        descriptor.Name("ClaimProcedureComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Date);
        descriptor.Field("procedureCodeableConcept")
            .Resolve(x => DataTypeResolvers.GetCodeableConceptValue(x.Parent<Claim.ProcedureComponent>().Procedure));

        descriptor.Field("procedureResourceReference")
            .Resolve(x => DataTypeResolvers.GetReferenceValue(x.Parent<Claim.ProcedureComponent>().Procedure))
            .Type<ResourceReferenceType<ClaimProcedureComponentProcedureResourceReferenceType>>();

        descriptor.Field(x => x.Sequence);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Udi).Type<ListType<ResourceReferenceType<ClaimProcedureComponentUdiReferenceType>>>();
    }
}

public class ClaimProcedureComponentUdiReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimProcedureComponentUdiReference");
        descriptor.Type<DeviceType>();
    }
}

public class ClaimProcedureComponentProcedureResourceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimProcedureComponentProcedureResourceReference");
        descriptor.Type<ProcedureType>();
    }
}

public class ClaimDiagnosisComponentType : ObjectType<Claim.DiagnosisComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.DiagnosisComponent> descriptor)
    {
        descriptor.Name("ClaimDiagnosisComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field("diagnosisReference")
            .Resolve(x => DataTypeResolvers.GetReferenceValue(x.Parent<Claim.DiagnosisComponent>().Diagnosis))
            .Type<ResourceReferenceType<ClaimDiagnosisComponentDiagnosisReferenceType>>();

        descriptor.Field("diagnosisCodeableConcept")
            .Resolve(x => DataTypeResolvers
                .GetCodeableConceptValue(x.Parent<Claim.DiagnosisComponent>().Diagnosis));

        descriptor.Field(x => x.OnAdmission);
        descriptor.Field(x => x.PackageCode);
        descriptor.Field(x => x.Sequence);
        descriptor.Field(x => x.Type);
    }
}

public class ClaimDiagnosisComponentDiagnosisReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimDiagnosisComponentDiagnosisReference");
        descriptor.Type<ConditionType>();
    }
}

public class ClaimPayeeComponentType : ObjectType<Claim.PayeeComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.PayeeComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Party).Type<ResourceReferenceType<ClaimPayeePartyReferenceType>>();
        descriptor.Field(x => x.Type);
    }
}

public class ClaimPayeePartyReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimPayeePartyReference");
        descriptor.Description("Reference(Practitioner|PractitionerRole|Organization|Patient|RelatedPerson)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class ClaimCareTeamComponentType : ObjectType<Claim.CareTeamComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Claim.CareTeamComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Sequence);
        descriptor.Field(x => x.Provider).Type<ResourceReferenceType<CareTeamProviderReferenceType>>();
        descriptor.Field(x => x.Responsible);
        descriptor.Field(x => x.Role);
        descriptor.Field(x => x.Qualification);
    }
}

public class CareTeamProviderReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CareTeamProviderReference");
        descriptor.Description("Reference(Practitioner|PractitionerRole|Organization)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ClaimFacilityReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimFacilityReference");

        descriptor.Type<LocationType>();
    }
}

public class ClaimReferralReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimReferralReference");

        descriptor.Type<ServiceRequestType>();
    }
}

public class ClaimProviderReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimProviderReference");
        descriptor.Description("Reference(Practitioner | PractitionerRole | Organization)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ClaimEntererReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimEntererReference");
        descriptor.Description("Reference(Practitioner | PractitionerRole)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
    }
}

public class ClaimInsurerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimInsurerReference");
        descriptor.Type<OrganizationType>();
    }
}

public class ClaimPatientReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ClaimPatientReference");
        descriptor.Type<PatientType>();
    }
}