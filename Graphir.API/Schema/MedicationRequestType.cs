using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationRequestType : ObjectType<MedicationRequest>
{
    // TODO: validate with graphQL FHIR spec document
    protected override void Configure(IObjectTypeDescriptor<MedicationRequest> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.InstantiatesCanonical);
        descriptor.Field(x => x.InstantiatesUri);
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<MedicationRequestBasedOnReferenceType>>>();
        descriptor.Field(x => x.PriorPrescription).Type<ResourceReferenceType<MedicationRequestPriorPrescriptionReferenceType>>();
        descriptor.Field(x => x.GroupIdentifier);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.StatusReason);
        descriptor.Field(x => x.Intent);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.DoNotPerform);
        descriptor.Field(x => x.Medication)
        .Type<CodeableReferenceType<MedicationRequestMedicationReferenceType>>()
        .Resolve(context =>
        {
            var parent = context.Parent<MedicationRequest>();
            if (parent.Medication is null)
                return null;

            if (parent.Medication.TypeName == "CodeableConcept")
            {
                return new CodeableReference
                {
                    Concept = (CodeableConcept)parent.Medication
                };
            }
            if (parent.Medication.TypeName == "Reference")
            {
                return new CodeableReference
                {
                    Reference = (ResourceReference)parent.Medication
                };
            }
            return null;
        });
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<MedicationRequestEncounterReferenceType>>();
        descriptor.Field(x => x.SupportingInformation).Type<ListType<ResourceReferenceType<MedicationRequestSupportingInformationReferenceType>>>();
        descriptor.Field(x => x.AuthoredOn);
        descriptor.Field(x => x.Requester).Type<ResourceReferenceType<MedicationRequestRequesterReferenceType>>();
        descriptor.Field(x => x.Reported).Type<BooleanType>().Resolve(r =>
        {
            var parent = r.Parent<MedicationRequest>();
            return parent.Reported is not null && parent.Reported.TypeName == "boolean"
                ? (FhirBoolean)parent.Reported
                : null;
        });
        descriptor.Field(x => x.PerformerType);
        descriptor.Field(x => x.Performer).Type<ResourceReferenceType<MedicationRequestPerformerReferenceType>>();
        descriptor.Field(x => x.Recorder).Type<ResourceReferenceType<MedicationRequestRecorderReferenceType>>();
        descriptor.Field(x => x.ReasonCode);
        descriptor.Field(x => x.ReasonReference).Type<ListType<ResourceReferenceType<MedicationRequestReasonReferenceType>>>();
        descriptor.Field(x => x.CourseOfTherapyType);
        descriptor.Field(x => x.Insurance).Type<ListType<ResourceReferenceType<MedicationRequestInsuranceReferenceType>>>();
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.DosageInstruction);
        descriptor.Field(x => x.DispenseRequest).Type<MedicationRequestDispenseRequestType>();
        descriptor.Field(x => x.Substitution).Type<MedicationRequestSubstitutionType>();
        descriptor.Field(x => x.DetectedIssue).Type<ListType<ResourceReferenceType<MedicationRequestDetectedIssueReferenceType>>>();
        descriptor.Field(x => x.EventHistory).Type<ListType<ResourceReferenceType<MedicationRequestEventHistoryReferenceType>>>();
    }
}

public class MedicationRequestDispenseRequestType : ObjectType<MedicationRequest.DispenseRequestComponent>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationRequest.DispenseRequestComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(m => m.Extension);
        descriptor.Field(m => m.ModifierExtension);
        descriptor.Field(m => m.InitialFill).Type<MedicationRequestDispenseRequestInitialFillType>();
        descriptor.Field(m => m.Extension);
    }
}

public class MedicationRequestDispenseRequestInitialFillType : ObjectType<MedicationRequest.InitialFillComponent>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationRequest.InitialFillComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(m => m.Extension);
        descriptor.Field(m => m.ModifierExtension);
        descriptor.Field(m => m.Quantity);
        descriptor.Field(m => m.Duration);
    }
}

public class MedicationRequestSubstitutionType : ObjectType<MedicationRequest.SubstitutionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationRequest.SubstitutionComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(m => m.Extension);
        descriptor.Field(m => m.ModifierExtension);
        descriptor.Field(m => m.Reason);
        descriptor.Field("allowedBoolean").Type<BooleanType>().Resolve(r =>
        {
            var parent = r.Parent<MedicationRequest.SubstitutionComponent>();
            return parent.Allowed is not null && parent.Allowed.TypeName == "boolean"
                ? (FhirBoolean)parent.Allowed
                : null;
        });
        descriptor.Field("allowedCodeableConcept").Type<CodeableConceptType>().Resolve(r =>
        {
            var parent = r.Parent<MedicationRequest.SubstitutionComponent>();
            return parent.Allowed is not null && parent.Allowed.TypeName == "CodeableConcept"
                ? (CodeableConcept)parent.Allowed
                : null;
        });
    }
}

public class MedicationRequestBasedOnReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestBasedOnReference");
        descriptor.Description("Reference(CarePlan | MedicationRequest | ServiceRequest | ImmunizationRecommendation)");
        //descriptor.Type<CarePlanType>();
        descriptor.Type<MedicationRequestType>();
        //descriptor.Type<ServiceRequestType>();
        //descriptor.Type<ImmunizationRecommendationType>();
    }
}

public class MedicationRequestPriorPrescriptionReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestPriorPrescriptionReference");
        descriptor.Description("Reference(MedicationRequest)");
        descriptor.Type<MedicationRequestType>();
    }
}

public class MedicationRequestEncounterReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestEncounterReference");
        descriptor.Description("Reference(Encounter)");
        descriptor.Type<EncounterType>();
    }
}

public class MedicationRequestInsuranceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("InsuranceReference");
        descriptor.Type<CoverageType>();
        //descriptor.Type<ClaimResponseType>();
    }
}

public class MedicationRequestReasonReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ReasonReference");
        descriptor.Type<ConditionType>();
        //descriptor.Type<ObservationType>();
    }
}

public class MedicationRequestSupportingInformationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SupportingInformationReference");
        descriptor.Type<ResourceType>();
    }
}

public class MedicationRequestPerformerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PerformerReference");
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<RelatedPersonType>();
        //descriptor.Type<CareTeamType>();
    }
}

public class MedicationRequestRecorderReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestRecorderReference");
        descriptor.Description("Reference(Practitioner | PractitionerRole)");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
    }
}

public class MedicationRequestDetectedIssueReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestDetectedIssueReference");
        descriptor.Description("Reference(DetectedIssue)");
        descriptor.Type<DetectedIssueType>();
    }
}

public class MedicationRequestEventHistoryReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestEventHistoryReference");
        descriptor.Description("Reference(Provenance)");
        descriptor.Type<ProvenanceType>();
    }
}

public class MedicationRequestRequesterReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestRequesterReference");
        descriptor.Description("Reference(Practitioner | PractitionerRole | Organization | Patient | RelatedPerson | Device)");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<DeviceType>();
    }
}

public class MedicationRequestMedicationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationRequestMedicationReference");
        descriptor.Description("Reference(Medication)");
        descriptor.Type<MedicationType>();
    }
}