using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationAdministrationType : ObjectType<MedicationAdministration>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationAdministration> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.StatusReason).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.ReasonCode).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Category).Type<CodeableConceptType>();
        descriptor.Field(x => x.Dosage).Type<DosageType>();
        descriptor.Field(x => x.Effective)
            .Type<PeriodType>().Name("effectivePeriod");
        descriptor.Field(x => x.Note).Type<StringType>();
        descriptor.Field(x => x.Performer).Type<ListType<PerformerComponentType>>();

        descriptor.Field(x => x.Medication);
        //     .Type<CodeableConceptType>().Name("medicationCodeableConcept");
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<MedicationSubjectReferenceType>>();
        // descriptor.Field(x => x.Request).Type<MedicationRequestType>();
        descriptor.Field(x => x.Device).Type<ResourceReferenceType<DeviceReferenceType>>();
        descriptor.Field(x => x.EventHistory).Type<ListType<ResourceReferenceType<EventHistoryReferenceType>>>();
    }
    
}

public class MedicationSubjectReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("MedicationSubjectReference");
        descriptor.Type<PatientType>();
        // TODO: descriptor.Type<GroupType>();
    }
}

public class EventHistoryReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EventHistoryReference");
        descriptor.Type<ProvenanceType>();
    }
}

public class PerformerComponentType : ObjectType<MedicationAdministration.PerformerComponent>
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

public class PerformerComponentActorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("PerformerComponentActorReference");
        descriptor.Type<PractitionerType>();
        //descriptor.Type<PractitionerRoleType>();
        descriptor.Type<PatientType>();
        //descriptor.Type<RelatedPersonType>();
        descriptor.Type<DeviceType>();
        // TODO: build out missing types
    }
}