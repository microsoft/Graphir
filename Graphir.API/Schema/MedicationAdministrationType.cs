using Graphir.API.DataLoaders;
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
        descriptor.Field(x => x.Note).Type<StringType>();
        descriptor.Field(x => x.Performer).Type<ListType<PerformerComponentType>>();

        descriptor.Field(x => x.Medication)
            .Type<CodeableReferenceType<MedicationAdministrationMedicationReferenceType>>()
            .Resolve(context =>
            {
                var parent = context.Parent<MedicationAdministration>();
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
        
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<MedicationAdministrationSubjectReferenceType>>();
        descriptor.Field(x => x.Request).Type<ResourceReferenceType<MedicationAdministrationRequestReferenceType>>();
        descriptor.Field(x => x.Device).Type<ResourceReferenceType<DeviceReferenceType>>();
        descriptor.Field(x => x.EventHistory).Type<ListType<ResourceReferenceType<MedicationAdministrationEventHistoryReferenceType>>>();

        descriptor.Field("effectivePeriod").Resolve(context =>
        {
            var parent = context.Parent<MedicationAdministration>();
            return (parent.Effective is not null && parent.Effective.TypeName == "Period")
                ? ((Period)parent.Effective)
                : null;
        });
        descriptor.Field("effectiveDateTime").Resolve(context =>
        {
            var parent = context.Parent<MedicationAdministration>();
            return (parent.Effective is not null && parent.Effective.TypeName == "dateTime")
                ? ((FhirDateTime)parent.Effective).Value
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
        // TODO: descriptor.Type<GroupType>();
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

#region QueryExtensions
public class MedicationAdministrationQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("MedicationAdministration")
            .Type<MedicationAdministrationType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<MedicationAdministration>>(r => r.GetResource(default!, default!));

        descriptor.Field("MedicationAdministrationList")
            .Type<ListType<MedicationAdministrationType>>()
            .ResolveWith<ResourceResolvers<MedicationAdministration>>(r => r.GetResources(default!));
    }
}
#endregion