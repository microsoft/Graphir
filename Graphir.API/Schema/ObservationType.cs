using Hl7.Fhir.Model;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;

namespace Graphir.API.Schema;

public class ObservationType : ObjectType<Observation>
{
    // TODO: finish Observation
    protected override void Configure(IObjectTypeDescriptor<Observation> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.BasedOn).Type<ResourceReferenceType<ObservationBasedOnReferenceType>>();
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<ObservationPartOfReferenceType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<ObservationSubjectReferenceType>>();
        descriptor.Field(x => x.Focus).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field("effectiveDateTime").Type<DateTimeType>().Resolve(r =>
        {
            var parent = r.Parent<Observation>();
            return parent.Effective is not null && parent.Effective.TypeName == "dateTime" ?
            (FhirDateTime)parent.Effective : null;
        });
        descriptor.Field("effectivePeriod").Resolve(r =>
        {
            var parent = r.Parent<Observation>();
            return parent.Effective is not null && parent.Effective.TypeName == "Period" ?
            (Period)parent.Effective : null;
        });
        descriptor.Field("effectiveTiming").Resolve(r =>
        {
            var parent = r.Parent<Observation>();
            return parent.Effective is not null && parent.Effective.TypeName == "Timing" ?
            (Timing)parent.Effective : null;
        });
        descriptor.Field("effectiveInstant").Resolve(r =>
        {
            var parent = r.Parent<Observation>();
            return parent.Effective is not null && parent.Effective.TypeName == "Instant" ?
            (Instant)parent.Effective : null;
        });
        descriptor.Field(x => x.Issued);
        descriptor.Field(x => x.Performer).Type<ListType<ResourceReferenceType<ObservationPerformerReferenceType>>>();
        descriptor.Field("valueQuantity").Resolve(r => ObservationValueResolver.GetValue<Quantity>(r.Parent<Observation>().Value));
        descriptor.Field("valueCodeableConcept").Resolve(r => ObservationValueResolver.GetValue<CodeableConcept>(r.Parent<Observation>().Value));
        descriptor.Field("valueString").Resolve(r => ObservationValueResolver.GetStringValue(r.Parent<Observation>().Value));
        descriptor.Field("valueBoolean").Type<BooleanType>()
            .Resolve(r => ObservationValueResolver.GetBooleanValue(r.Parent<Observation>().Value));
        descriptor.Field("valueInteger").Resolve(r => ObservationValueResolver.GetIntegerValue(r.Parent<Observation>().Value));
        descriptor.Field("valueRange").Resolve(r => ObservationValueResolver.GetValue<Range>(r.Parent<Observation>().Value));
        descriptor.Field("valueRatio").Resolve(r => ObservationValueResolver.GetValue<Ratio>(r.Parent<Observation>().Value));
        descriptor.Field("valueSampledData").Resolve(r => ObservationValueResolver.GetValue<SampledData>(r.Parent<Observation>().Value));
        descriptor.Field("valueTime").Resolve(r => ObservationValueResolver.GetTimeValue(r.Parent<Observation>().Value));
        descriptor.Field("valueDateTime").Type<DateTimeType>()
            .Resolve(r => ObservationValueResolver.GetValue<FhirDateTime>(r.Parent<Observation>().Value));
        descriptor.Field("valuePeriod").Resolve(r => ObservationValueResolver.GetValue<Period>(r.Parent<Observation>().Value));
        descriptor.Field("valueAttachment").Resolve(r => ObservationValueResolver.GetValue<Attachment>(r.Parent<Observation>().Value));
        descriptor.Field(x => x.DataAbsentReason);
        descriptor.Field(x => x.Interpretation);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.BodySite);
        descriptor.Field(x => x.Method);
        descriptor.Field(x => x.Specimen).Type<ResourceReferenceType<SpecimenReferenceType>>();
        descriptor.Field(x => x.Device).Type<ResourceReferenceType<ObservationDeviceReferenceType>>();
        descriptor.Field(x => x.ReferenceRange).Type<ListType<ObservationReferenceRangeType>>();
        descriptor.Field(x => x.HasMember).Type<ListType<ResourceReferenceType<ObservationHasMemberReferenceType>>>();
        descriptor.Field(x => x.DerivedFrom).Type<ListType<ResourceReferenceType<ObservationDerivedFromReferenceType>>>();
        descriptor.Field(x => x.Component).Type<ListType<ObservationComponent>>();
    }

    private class ObservationValueResolver
    {
        public static T? GetValue<T>(DataType? value) where T : DataType 
        {
            return value is not null && value.TypeName == typeof(T).Name ?
                (T)value : null;
        }

        public static FhirString? GetStringValue(DataType? value)
        {
            return value is not null && value.TypeName == "string" ?
                (FhirString)value : null;
        }
        public static FhirBoolean? GetBooleanValue(DataType? value)
        {
            return value is not null && value.TypeName == "boolean" ?
                (FhirBoolean)value : null;
        }

        public static int? GetIntegerValue(DataType? value)
        {
            return value is not null && value.TypeName == "integer" ?
                ((Integer)value).Value : null;
        }

        public static string? GetTimeValue(DataType? value)
        {
            return value is not null && value.TypeName == "time" ?
                ((Time)value).Value : null;
        }

        public static FhirDateTime? GetDateTimeValue(DataType? value)
        {
            return value is not null && value.TypeName == "dateTime" ?
                (FhirDateTime)value : null;
        }
    }

    private class ObservationBasedOnReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ObservationBasedOnReferenceType");
            descriptor.Description("Reference(CarePlan | DeviceRequest | ImmunizationRecommendation | MedicationRequest | NutritionOrder | ServiceRequest)");
            descriptor.Type<CarePlanType>();
            descriptor.Type<DeviceRequestType>();
            descriptor.Type<ImmunizationRecommendationType>();
            descriptor.Type<MedicationRequestType>();
            descriptor.Type<NutritionOrderType>();
            descriptor.Type<ServiceRequestType>();
        }
    }

    private class ObservationPartOfReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ObservationPartOfReference");
            descriptor.Description("Reference(MedicationAdministration | MedicationDispense | MedicationStatement | Procedure | Immunization | ImagingStudy)");
            descriptor.Type<MedicationAdministrationType>();
            //descriptor.Type<MedicationDispenseType>();
            descriptor.Type<MedicationStatementType>();
            //descriptor.Type<ProcedureType>();
            //descriptor.Type<ImmunizationType>();
            //descriptor.Type<ImagingStudyType>();
        }
    }

    private class ObservationSubjectReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ObservationSubjectReferenceType");
            descriptor.Description("Reference(Patient | Group | Device | Location | Organization | Procedure | Practitioner | Medication | Substance)");
            descriptor.Type<PatientType>();
            descriptor.Type<GroupType>();
            descriptor.Type<DeviceType>();
            descriptor.Type<LocationType>();
            descriptor.Type<OrganizationType>();
            //descriptor.Type<ProcedureType>();
            descriptor.Type<PractitionerType>();
            descriptor.Type<MedicationType>();
            descriptor.Type<SubstanceType>();
        }
    }

    private class ObservationPerformerReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ObservationPerformerReference");
            descriptor.Description("Reference(Practitioner | PractitionerRole | Organization | CareTeam | Patient | RelatedPerson)");
            descriptor.Type<PractitionerType>();
            descriptor.Type<PractitionerRoleType>();
            descriptor.Type<OrganizationType>();
            descriptor.Type<CareTeamType>();
            descriptor.Type<PatientType>();
            descriptor.Type<RelatedPersonType>();
        }
    }

    private class ObservationDeviceReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Description("Reference(Device | DeviceMetric)");
            descriptor.Type<DeviceType>();
            //descriptor.Type<DeviceMetricType>();
        }
    }

    private class ObservationReferenceRangeType : ObjectType<Observation.ReferenceRangeComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Observation.ReferenceRangeComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Low);
            descriptor.Field(x => x.High);
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.AppliesTo);
            descriptor.Field(x => x.Age);
            descriptor.Field(x => x.Text);
        }
    }

    private class ObservationHasMemberReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ObservationHasMemberReference");
            descriptor.Description("Reference(Observation | QuestionnaireResponse | MolecularSequence)");
            descriptor.Type<ObservationType>();
            //descriptor.Type<QuestionnaireResponseType>();
            //descriptor.Type<MolecularSequenceType>();
        }
    }

    private class ObservationDerivedFromReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("ObservationDerivedFromReference");
            descriptor.Description("Reference(DocumentReference | ImagingStudy | Media | QuestionnaireResponse | Observation | MolecularSequence)");
            //descriptor.Type<DocumentReferenceType>();
            //descriptor.Type<ImagingStudyType>();
            //descriptor.Type<MediaType>();
            //descriptor.Type<QuestionnaireResponseType>();
            descriptor.Type<ObservationType>();
            //descriptor.Type<MolecularSequenceType>();
        }
    }

    private class ObservationComponent : ObjectType<Observation.ComponentComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Observation.ComponentComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Code);
            descriptor.Field("valueQuantity").Resolve(r => ObservationValueResolver.GetValue<Quantity>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueCodeableConcept").Resolve(r => ObservationValueResolver.GetValue<CodeableConcept>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueString").Resolve(r => ObservationValueResolver.GetStringValue(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueBoolean").Type<BooleanType>()
                .Resolve(r => ObservationValueResolver.GetBooleanValue(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueInteger").Resolve(r => ObservationValueResolver.GetIntegerValue(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueRange").Resolve(r => ObservationValueResolver.GetValue<Range>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueRatio").Resolve(r => ObservationValueResolver.GetValue<Ratio>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueSampledData").Resolve(r => ObservationValueResolver.GetValue<SampledData>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueTime").Resolve(r => ObservationValueResolver.GetTimeValue(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueDateTime").Type<DateTimeType>()
                .Resolve(r => ObservationValueResolver.GetValue<FhirDateTime>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valuePeriod").Resolve(r => ObservationValueResolver.GetValue<Period>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field("valueAttachment").Resolve(r => ObservationValueResolver.GetValue<Attachment>(r.Parent<Observation.ComponentComponent>().Value));
            descriptor.Field(x => x.DataAbsentReason);
            descriptor.Field(x => x.Interpretation);
            descriptor.Field(x => x.ReferenceRange).Type<ListType<ObservationReferenceRangeType>>();
        }
    }
}
