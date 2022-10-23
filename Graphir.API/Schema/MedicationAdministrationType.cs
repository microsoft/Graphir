using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationAdministrationType : ObjectType<MedicationAdministration>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationAdministration> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.StatusReason);
        descriptor.Field(x => x.ReasonCode);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Dosage).Type<MedicationAdministrationDosageType>();
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.Performer).Type<ListType<MedicationAdministrationPerformerComponentType>>();

        descriptor.Field(x => x.Medication)
            .Type<CodeableReferenceType<MedicationAdministrationMedicationReferenceType>>()
            .Resolve(context =>
            {
                var parent = context.Parent<MedicationAdministration>();
                return parent.Medication is null
                    ? null
                    : parent.Medication.TypeName switch
                    {
                        "CodeableConcept" => new CodeableReference { Concept = (CodeableConcept)parent.Medication },
                        "Reference" => new CodeableReference { Reference = (ResourceReference)parent.Medication },
                        _ => null
                    };
            });

        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<MedicationAdministrationSubjectReferenceType>>();
        descriptor.Field(x => x.Request).Type<ResourceReferenceType<MedicationAdministrationRequestReferenceType>>();
        descriptor.Field(x => x.Device).Type<ResourceReferenceType<DeviceReferenceType>>();
        descriptor.Field(x => x.EventHistory)
            .Type<ListType<ResourceReferenceType<MedicationAdministrationEventHistoryReferenceType>>>();

        descriptor.Field("effectivePeriod").Type<PeriodType>().Resolve(context =>
        {
            var parent = context.Parent<MedicationAdministration>();
            return parent.Effective is not null && parent.Effective.TypeName == "Period"
                ? (Period)parent.Effective
                : null;
        });
        descriptor.Field("effectiveDateTime").Type<DateTimeType>().Resolve(context =>
        {
            var parent = context.Parent<MedicationAdministration>();
            return parent.Effective is not null && parent.Effective.TypeName == "dateTime"
                ? ((FhirDateTime)parent.Effective).Value
                : null;
        });
    }
}

public class MedicationAdministrationPerformerComponentType : ObjectType<MedicationAdministration.PerformerComponent>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationAdministration.PerformerComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Actor).Type<ResourceReferenceType<PerformerComponentActorReferenceType>>();
        descriptor.Field(x => x.TypeName).Type<CodeableConceptType>();
        descriptor.Field(x => x.Function).Type<CodeableConceptType>();
        descriptor.Field(x => x.Extension).Type<ListType<ExtensionType>>();
    }
}

public class MedicationAdministrationDosageType : ObjectType<MedicationAdministration.DosageComponent>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationAdministration.DosageComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Site);
        descriptor.Field(x => x.Route);
        descriptor.Field(x => x.Method);
        descriptor.Field(x => x.Dose);
        descriptor.Field("rateRatio").Type<RatioType>().Resolve(r =>
        {
            var parent = r.Parent<MedicationAdministration.DosageComponent>();
            return parent.Rate is not null && parent.Rate.TypeName == "Ratio"
                ? (Ratio)parent.Rate
                : null;
        });

        descriptor.Field("rateQuantity").Type<QuantityType>().Resolve(r =>
        {
            var parent = r.Parent<MedicationAdministration.DosageComponent>();
            return parent.Rate is not null && parent.Rate.TypeName == "Quantity"
                ? (Quantity)parent.Rate
                : null;
        });
    }
}

public class MedicationAdministrationRequestReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationAdministrationRequestReference");
        descriptor.Type<MedicationRequestType>();
    }
}

public class MedicationAdministrationMedicationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationAdministrationMedicationReference");
        descriptor.Type<MedicationType>();
    }
}

public class MedicationAdministrationSubjectReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationAdministrationSubjectReference");
        descriptor.Type<PatientType>();
        descriptor.Type<GroupType>();
    }
}

public class MedicationAdministrationEventHistoryReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationAdministrationEventHistoryReference");
        descriptor.Type<ProvenanceType>();
    }
}

public class PerformerComponentActorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PerformerComponentActorReference");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<DeviceType>();
    }
}