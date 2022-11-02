using Hl7.Fhir.Model;
using HotChocolate.Types;

using static System.StringComparison;
using static Hl7.Fhir.Model.Observation;

namespace Graphir.API.Schema;

public class ObservationType : ObjectType<Observation>
{
    protected override void Configure(IObjectTypeDescriptor<Observation> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Interpretation);
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<ObservationBasedOnType>>>();
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<ObservationPartOfType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<ObservationSubjectType>>();
        descriptor.Field(x => x.Focus).Type<ListType<ResourceReferenceType<ObservationFocusType>>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<ObservationEncounterType>>();
        descriptor.Field(x => x.Method);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.Performer).Type<ListType<ResourceReferenceType<ObservationPerformerType>>>();
        descriptor.Field(x => x.Specimen).Type<ResourceReferenceType<ObservationSpecimenType>>();
        descriptor.Field(x => x.Issued);
        
        descriptor.Field("valueQuantity").Type<QuantityType>()
            .Resolve(x => x.Parent<Observation>() is { Value: Quantity value } &&
                          value.TypeName.Equals("Quantity", OrdinalIgnoreCase) 
                ? value : null);

        descriptor.Field("valueCodeableConcept").Type<CodeableConceptType>()
            .Resolve(x => x.Parent<Observation>() is { Value: CodeableConcept value } &&
                          value.TypeName.Equals("codeableConcept", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueString").Type<StringType>() 
            .Resolve(x => x.Parent<Observation>() is { Value: FhirString value } &&
                          value.TypeName.Equals("String", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueBoolean").Type<BooleanType>() 
            .Resolve(x => x.Parent<Observation>() is { Value: FhirBoolean value } &&
                          value.TypeName.Equals("Boolean", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueInteger").Type<IntType>() 
            .Resolve(x => x.Parent<Observation>() is { Value: Integer value } &&
                          value.TypeName.Equals("Integer", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueRange").Type<RangeType>() 
            .Resolve(x => x.Parent<Observation>() is { Value: Range value } &&
                          value.TypeName.Equals("Range", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueRatio").Type<RatioType>() 
            .Resolve(x => x.Parent<Observation>() is { Value: Ratio value } &&
                          value.TypeName.Equals("Ratio", OrdinalIgnoreCase) 
                ? value : null);

        /*
         descriptor.Field("valueSampledData").Type<SampledDataType>() 
            .Resolve(x => x.Parent<Observation>().Value is SampledData value &&
                          nameof(value).Equals("valueSampledData", InvariantCultureIgnoreCase)
                ? value
                : null);
         */

        descriptor.Field("valueTime").Type<TimeType>()
            .Resolve(x => x.Parent<Observation>() is {Effective: Time value} &&
                          nameof(value).Equals("Time", OrdinalIgnoreCase)
                ? value
                : null);
        
        descriptor.Field("valueDateTime").Type<DateTimeType>() 
            .Resolve(x => x.Parent<Observation>() is {Effective: FhirDateTime value} &&
                          nameof(value).Equals("DateTime", OrdinalIgnoreCase)
                ? value
                : null);
        
        descriptor.Field("valuePeriod").Type<PeriodType>() 
            .Resolve(x => x.Parent<Observation>() is {Effective: Period value} &&
                          nameof(value).Equals("Period", OrdinalIgnoreCase)
                ? value
                : null);

        descriptor.Field(x => x.BodySite);
        descriptor.Field(x => x.DerivedFrom).Type<ListType<ResourceReferenceType<ObservationDerivedFromType>>>();
        descriptor.Field(x => x.HasMember).Type<ListType<ResourceReferenceType<ObservationHasMemberType>>>();
        descriptor.Field(x => x.IssuedElement);
        descriptor.Field(x => x.ReferenceRange).Type<ListType<ReferenceRangeComponentType>>();
        descriptor.Field(x => x.StatusElement).Type<StringType>(); // Should specify as StringType
        descriptor.Field(x => x.TypeName);
        descriptor.Field(x => x.DataAbsentReason);
        descriptor.Field(x => x.HasVersionId);
        descriptor.Field(x => x.VersionId);

        descriptor.Field("effectiveDateTime").Type<DateTimeType>()
            .Resolve(x => x.Parent<Observation>() is { Effective: FhirDateTime value } &&
                          value.TypeName.Equals("dateTime", OrdinalIgnoreCase) 
                ? value : null);

        descriptor.Field("effectivePeriod").Type<PeriodType>()
            .Resolve(x => x.Parent<Observation>() is { Effective: Period value } &&
                          value.TypeName.Equals("Period", OrdinalIgnoreCase)
                ? value : null);

        descriptor.Field("effectiveTiming").Type<TimingType>()
            .Resolve(x => x.Parent<Observation>() is { Effective: Timing value } &&
                          value.TypeName.Equals("Time", OrdinalIgnoreCase)
                ? value : null);

        descriptor.Field("effectiveInstant").Type<InstantType>()
            .Resolve(x => x.Parent<Observation>() is { Effective: Instant value } &&
                          value.TypeName.Equals("Instant", OrdinalIgnoreCase)
                ? value : null);

        descriptor.Field(x => x.Device).Type<ResourceReferenceType<ObservationDeviceType>>();
        descriptor.Field(x => x.Component).Type<ListType<ComponentComponentType>>();
    }
}

public class ComponentComponentType : ObjectType<ComponentComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ComponentComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.DataAbsentReason);
        descriptor.Field(x => x.Interpretation);
        descriptor.Field(x => x.ReferenceRange).Type<ListType<ReferenceRangeComponentType>>();

        descriptor.Field("valueQuantity").Type<QuantityType>()
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: Quantity value } &&
                          value.TypeName.Equals("Quantity", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueCodeableConcept").Type<CodeableConceptType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: CodeableConcept value } &&
                          value.TypeName.Equals("codeableConcept", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueString").Type<StringType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: FhirString value } &&
                          value.TypeName.Equals("String", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueBoolean").Type<BooleanType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: FhirBoolean value } &&
                          value.TypeName.Equals("Boolean", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueInteger").Type<IntType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: Integer value } &&
                          value.TypeName.Equals("Integer", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueRange").Type<RangeType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: Range value } &&
                          value.TypeName.Equals("Range", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueRatio").Type<RatioType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: Ratio value } &&
                          value.TypeName.Equals("Ratio", OrdinalIgnoreCase) 
                ? value : null);
        
        /*
         descriptor.Field("valueSampledData").Type<SampledDataType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: SampledData value } &&
                          value.TypeName.Equals("SampledData", OrdinalIgnoreCase) 
                ? value : null);
        */
        
        descriptor.Field("valueTime").Type<TimeType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: Time value } &&
                          value.TypeName.Equals("Time", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valueDateTime").Type<DateTimeType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: FhirDateTime value } &&
                          value.TypeName.Equals("DateTime", OrdinalIgnoreCase) 
                ? value : null);
        
        descriptor.Field("valuePeriod").Type<PeriodType>() 
            .Resolve(x => x.Parent<ComponentComponent>() is { Value: Period value } &&
                          value.TypeName.Equals("Period", OrdinalIgnoreCase) 
                ? value : null);
    }
}

public class ObservationDeviceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationDeviceType");

        descriptor.Type<DeviceType>();
        // descriptor.Type<DeviceMetricType>();
    }
}

public class ReferenceRangeComponentType : ObjectType<ReferenceRangeComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ReferenceRangeComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Low);
        descriptor.Field(x => x.High);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.AppliesTo);
        descriptor.Field(x => x.Age);
        descriptor.Field(x => x.TextElement);
        descriptor.Field(x => x.Text);
    }
}

public class ObservationHasMemberType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationHasMemberType");
        descriptor.Description(
            "Related resource that belongs to the Observation group. Reference(Observation | QuestionnaireResponse | MolecularSequence)");

        descriptor.Type<ObservationType>();
        /* TODO: Add below types
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<MolecularSequenceType>();
        */
    }
}

public class ObservationDerivedFromType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationDerivedFromType");
        descriptor.Description(
            "Related measurements the observation is made from. Reference(DocumentReference | ImagingStudy | Media | QuestionnaireResponse | Observation | MolecularSequence)");

        descriptor.Type<ObservationType>();

        /* TODO: Add below types 
        descriptor.Type<DocumentReferenceType>();
        descriptor.Type<ImagingStudyType>();
        descriptor.Type<MediaType>();
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<MolecularSequenceType>();
        */
    }
}

public class ObservationSpecimenType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationSpecimenType");
        descriptor.Description("Specimen used for this observation");

        descriptor.Type<SpecimenType>();
    }
}

public class ObservationPerformerType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationPerformerType");
        descriptor.Description(
            "Who is responsible for the observation. Reference(Practitioner | PractitionerRole | Organization | CareTeam | Patient | RelatedPerson)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        // descriptor.Type<CareTeamType>(); TODO: CareTeamType is not implemented yet
    }
}

public class ObservationEncounterType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationEncounterType");
        descriptor.Description("Healthcare event during which this observation is made");

        descriptor.Type<EncounterType>();
    }
}

public class ObservationFocusType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationFocusType");
        descriptor.Description("What the observation is about, when it is not about the subject of record");

        descriptor.Type<ResourceType>();
    }
}

public class ObservationSubjectType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationSubjectType");
        descriptor.Description(
            "Who and/or what the observation is about. Reference(Patient|Group|Device|Location|Organization|Procedure|Practitioner|Medication|Substance)");
        descriptor.Type<PatientType>();
        descriptor.Type<GroupType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<LocationType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<MedicationType>();
        descriptor.Type<SubstanceType>();
        // descriptor.Type<ProcedureType>(); TODO: Add ProcedureType 
    }
}

public class ObservationPartOfType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationPartOfType");
        descriptor.Description(
            "Part of referenced event. Reference(Procedure | Immunization | MedicationAdministration | MedicationDispense | MedicationStatement | ImagingStudy)");
        descriptor.Type<MedicationAdministrationType>();

        /* TODO: Add below types
        descriptor.Type<ProcedureType>();
        descriptor.Type<ImmunizationType>();
        descriptor.Type<MedicationDispenseType>();
        descriptor.Type<MedicationStatementType>();
        descriptor.Type<ImagingStudyType>();
        */
    }
}

public class ObservationBasedOnType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationBasedOn");
        descriptor.Description(
            "Fulfills plan, proposal or order. Reference(CarePlan | DeviceRequest | ImmunizationRecommendation | MedicationRequest | NutritionOrder | ServiceRequest)");

        descriptor.Type<CarePlanType>();
        descriptor.Type<MedicationRequestType>();
        descriptor.Type<ServiceRequestType>();
        /* TODO: Add below types
        descriptor.Type<DeviceRequestType>();
        descriptor.Type<ImmunizationRecommendationType>();
        descriptor.Type<NutritionOrderType>();
        */
    }
}