using Hl7.Fhir.Model;
using HotChocolate.Types;
using System.Linq;

namespace Graphir.API.Schema;

public class ServiceRequestType : ObjectType<ServiceRequest>
{
    protected override void Configure(IObjectTypeDescriptor<ServiceRequest> descriptor)
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
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<BasedOnReferenceType>>>();
        descriptor.Field(x => x.Replaces).Type<ListType<ResourceReferenceType<ReplacesReferenceType>>>();
        descriptor.Field(x => x.Requisition);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Intent);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.DoNotPerform);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.OrderDetail);
        descriptor.Field("quantityQuantity").Type<QuantityType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.Quantity is not null && parent.Quantity.TypeName == "Quantity"
            ? (Quantity)parent.Quantity
            : null;
        });
        descriptor.Field("quantityRatio").Type<RatioType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.Quantity is not null && parent.Quantity.TypeName == "Ratio"
            ? (Ratio)parent.Quantity
            : null;
        });
        descriptor.Field("quantityRange").Type<RangeType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.Quantity is not null && parent.Quantity.TypeName == "Range"
            ? (Range)parent.Quantity
            : null;
        });
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field("occurrenceDateTime").Type<DateTimeType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.Occurrence is not null && parent.Occurrence.TypeName == "dateTime"
            ? (FhirDateTime)parent.Occurrence
            : null;
        });
        descriptor.Field("occurrencePeriod").Type<PeriodType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.Occurrence is not null && parent.Occurrence.TypeName == "Period"
            ? (Period)parent.Occurrence
            : null;
        });
        descriptor.Field("occurrenceTiming").Type<TimingType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.Occurrence is not null && parent.Occurrence.TypeName == "Timing"
            ? (Timing)parent.Occurrence
            : null;
        });
        descriptor.Field("asNeededBoolean").Type<BooleanType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.AsNeeded is not null && parent.AsNeeded.TypeName == "boolean"
            ? (FhirBoolean)parent.AsNeeded
            : null;
        });
        descriptor.Field("asNeededCodeableConcept").Type<CodeableConceptType>().Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();
            return parent.AsNeeded is not null && parent.AsNeeded.TypeName == "CodeableConcept"
            ? (CodeableConcept)parent.AsNeeded
            : null;
        });
        descriptor.Field(x => x.AuthoredOn);
        descriptor.Field(x => x.Requester).Type<ResourceReferenceType<RequesterReferenceType>>();
        descriptor.Field(x => x.PerformerType);
        descriptor.Field(x => x.Performer).Type<ListType<ResourceReferenceType<PerformerReferenceType>>>();
        descriptor.Field("location").Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();

            if (parent.LocationCode is not null)
                return parent.LocationCode.Select(c => new CodeableReference { Concept = c });
            if (parent.LocationReference is not null)
                return parent.LocationReference.Select(c => new CodeableReference { Reference = c });

            return null;
        });
        descriptor.Field("reason").Resolve(r =>
        {
            var parent = r.Parent<ServiceRequest>();

            if (parent.ReasonCode is not null)
                return parent.ReasonCode.Select(x => new CodeableReference { Concept = x });
            if (parent.ReasonReference is not null)
                return parent.ReasonReference.Select(x => new CodeableReference { Reference = x });

            return null;
        });
        descriptor.Field(x => x.Insurance).Type<ListType<ResourceReferenceType<InsuranceReferenceType>>>();
        descriptor.Field(x => x.SupportingInfo).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
        descriptor.Field(x => x.Specimen).Type<ListType<ResourceReferenceType<SpecimenReferenceType>>>();
        descriptor.Field(x => x.BodySite);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.PatientInstruction);
        descriptor.Field(x => x.RelevantHistory).Type<ListType<ResourceReferenceType<ProvenanceReferenceType>>>();
    }

    private class BasedOnReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ServiceRequestBasedOnReference");
            descriptor.Description("Reference(CarePlan | ServiceRequest | MedicationRequest)");
            descriptor.Type<CarePlanType>();
            descriptor.Type<ServiceRequestType>();
            descriptor.Type<MedicationRequestType>();
        }
    }

    private class ReplacesReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ServiceRequestReplacesReference");
            descriptor.Description("Reference(ServiceRequest)");
            descriptor.Type<ServiceRequestType>();
        }
    }

    private class SubjectReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ServiceRequestSubjectReference");
            descriptor.Description("Reference(Patient | Group | Location | Device)");
            descriptor.Type<PatientType>();
            descriptor.Type<GroupType>();
            descriptor.Type<LocationType>();
            descriptor.Type<DeviceType>();
        }
    }

    private class EncounterReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ServiceRequestEncounterReference");
            descriptor.Description("Reference(Encounter)");
            descriptor.Type<EncounterType>();
        }
    }

    private class RequesterReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ServiceRequestRequesterReference");
            descriptor.Description("Reference(Practitioner | PractitionerRole | Organization | Patient | RelatedPerson | Device)");
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<PatientType>();
            descriptor.Type<RelatedPersonType>();
            descriptor.Type<DeviceType>();
        }
    }

    private class PerformerReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ServiceRequestPerformerReference");
            descriptor.Description("Reference(Practitioner | PractitionerRole | Organization | CareTeam | HealthcareService | Patient | Device | RelatedPerson)");
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<CareTeamType>();
            descriptor.Type<HealthcareServiceType>();
            descriptor.Type<PatientType>();
            descriptor.Type<DeviceType>();
            descriptor.Type<RelatedPersonType>();
        }
    }

    private class InsuranceReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ServiceRequestInsuranceReference");
            descriptor.Description("Reference(Coverage | ClaimResponse)");
            descriptor.Type<CoverageType>();
            descriptor.Type<ClaimType>();
        }
    }

}
