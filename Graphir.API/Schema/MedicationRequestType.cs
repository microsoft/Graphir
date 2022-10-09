using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationRequestType : ObjectType<MedicationRequest>
{
    // TODO: validate with graphQL FHIR spec document
    protected override void Configure(IObjectTypeDescriptor<MedicationRequest> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.StatusReason).Type<CodeableConceptType>();
        descriptor.Field(x => x.Intent).Type<StringType>();
        descriptor.Field(x => x.Category).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Priority).Type<StringType>();
        descriptor.Field(x => x.DoNotPerform).Type<BooleanType>();
        descriptor.Field(x => x.Reported).Type<StringType>();

        //descriptor.Field(x => x.SupportingInformation).Type<ListType<ResourceReferenceType<SupportingInformationReferenceType>>>();
        descriptor.Field(x => x.AuthoredOn).Type<StringType>();
        
        descriptor.Field(x => x.Performer).Type<ResourceReferenceType<MedicationRequestPerformerReferenceType>>();
        descriptor.Field(x => x.PerformerType).Type<CodeableConceptType>();
        descriptor.Field(x => x.Recorder).Type<PractitionerType>();
        descriptor.Field(x => x.ReasonCode).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.ReasonReference).Type<ListType<ResourceReferenceType<MedicationRequestReasonReferenceType>>>();
        descriptor.Field(x => x.InstantiatesCanonical).Type<ListType<StringType>>();
        descriptor.Field(x => x.InstantiatesUri).Type<ListType<StringType>>();
        descriptor.Field(x => x.GroupIdentifier).Type<IdentifierType>();
        descriptor.Field(x => x.CourseOfTherapyType).Type<CodeableConceptType>();
        descriptor.Field(x => x.Insurance).Type<ListType<ResourceReferenceType<MedicationRequestInsuranceReferenceType>>>();
        descriptor.Field(x => x.DosageInstruction).Type<ListType<DosageType>>();
        
        // descriptor.Field(x => x.Requester); //TODO:Resolvers
        //descriptor.Field(x => x.Note).Type<ListType<AnnotationType>>();
        // descriptor.Field(x => x.Medication).Type<MedicationType>();
        // descriptor.Field(x => x.Subject).Type<PatientType>();
        // descriptor.Field(x => x.Encounter).Type<ResourceReferenceType>();
        // descriptor.Field(x => x.DispenseRequest).Type<MedicationRequestDispenseRequestType>();
        // descriptor.Field(x => x.Substitution).Type<MedicationRequestSubstitutionType>();
        // descriptor.Field(x => x.PriorPrescription).Type<ReferenceType>();
        // descriptor.Field(x => x.DetectedIssue).Type<ListType<ReferenceType>>();
        // descriptor.Field(x => x.EventHistory).Type<ListType<ReferenceType>>();
        
    }
}

public class MedicationRequestInsuranceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("InsuranceReference");
        descriptor.Type<CoverageType>();
        // TODO: descriptor.Type<ClaimResponseType>();
    }
}

public class MedicationRequestReasonReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ReasonReference");
        descriptor.Type<ConditionType>();
        // TODO: descriptor.Type<ObservationType>();
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
        //descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<DeviceType>();
        //descriptor.Type<RelatedPersonType>();
        //descriptor.Type<CareTeamType>();
    }
}

public class DosageType : ObjectType<Dosage>
{
    protected override void Configure(IObjectTypeDescriptor<Dosage> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Sequence).Type<IntType>();
        descriptor.Field(x => x.Text).Type<StringType>();
        descriptor.Field(x => x.AdditionalInstruction).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.PatientInstruction).Type<StringType>();
        descriptor.Field(x => x.Timing).Type<TimingType>();
        descriptor.Field(x => x.Site).Type<CodeableConceptType>();
        descriptor.Field(x => x.Route).Type<CodeableConceptType>();
        descriptor.Field(x => x.Method).Type<CodeableConceptType>();
        descriptor.Field(x => x.DoseAndRate).Type<ListType<DoseAndRateType>>();
        descriptor.Field(x => x.MaxDosePerPeriod).Type<RatioType>();
        descriptor.Field(x => x.MaxDosePerAdministration).Type<QuantityType>();
        descriptor.Field(x => x.MaxDosePerLifetime).Type<QuantityType>();
        descriptor.Field(x => x.AsNeeded).Type<ListType<CodeableConceptType>>();
    }
}

public class DoseAndRateType : ObjectType<Dosage.DoseAndRateComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Dosage.DoseAndRateComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Type).Type<CodeableConceptType>();
        descriptor.Field(x => x.Dose).Type<QuantityType>();
        descriptor.Field(x => x.Rate).Type<RatioType>();
    }
}

public class TimingType : ObjectType<Timing>
{
    protected override void Configure(IObjectTypeDescriptor<Timing> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Event).Type<ListType<StringType>>();
        descriptor.Field(x => x.Repeat).Type<RepeatComponentType>();
        descriptor.Field(x => x.Code).Type<CodeableConceptType>();
    }
}

public class RepeatComponentType : ObjectType<Timing.RepeatComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Timing.RepeatComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        //descriptor.Field(x => x.Bounds).Type<DurationType>(); TODO:Resolvers
        descriptor.Field(x => x.Count);
        descriptor.Field(x => x.CountMax);
        descriptor.Field(x => x.Duration);
        descriptor.Field(x => x.DurationMax);
        descriptor.Field(x => x.DurationUnit);
        descriptor.Field(x => x.Frequency);
        descriptor.Field(x => x.FrequencyMax);
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.PeriodMax);
        descriptor.Field(x => x.PeriodUnit);
        descriptor.Field(x => x.DayOfWeek);
        descriptor.Field(x => x.TimeOfDay);
        descriptor.Field(x => x.When);
        descriptor.Field(x => x.Offset);
    }
}

#region QueryExtensions
public class MedicationRequestQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("MedicationRequest")
            .Type<MedicationRequestType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<MedicationRequest>>(r => r.GetResource(default!, default!));

        descriptor.Field("MedicationRequestList")
            .Type<ListType<MedicationRequestType>>()
            .ResolveWith<ResourceResolvers<MedicationRequest>>(r => r.GetResources());
    }
}
#endregion