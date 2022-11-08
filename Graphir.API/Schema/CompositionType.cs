using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

using static Hl7.Fhir.Model.Composition;

namespace Graphir.API.Schema;

public class CompositionType : ObjectType<Composition>
{
    protected override void Configure(IObjectTypeDescriptor<Composition> descriptor)
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
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<CompositionSubjectReferenceType>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<CompositionEncounterReferenceType>>();
        descriptor.Field(x => x.Date);
        descriptor.Field(x => x.Author).Type<ResourceReferenceType<CompositionAuthorReferenceType>>();
        descriptor.Field(x => x.Title);
        descriptor.Field(x => x.Confidentiality_);
        descriptor.Field(x => x.Attester).Type<ListType<CompositionAttesterComponentType>>();
        descriptor.Field(x => x.Custodian).Type<ResourceReferenceType<CompositionCustodianReferenceType>>();
        descriptor.Field(x => x.RelatesTo).Type<ListType<CompositionRelatesToComponentType>>();
        descriptor.Field(x => x.Event).Type<ListType<EventComponentType>>();
        descriptor.Field(x => x.Section).Type<ListType<SectionComponentType>>();
    }
}

public class SectionComponentType : ObjectType<SectionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<SectionComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Title);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Author).Type<ResourceReferenceType<SectionComponentAuthorReferenceType>>();
        descriptor.Field(x => x.Focus).Type<ResourceReferenceType<SectionComponentFocusReferenceType>>();
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Mode);
        descriptor.Field(x => x.OrderedBy);
        descriptor.Field(x => x.Entry).Type<ListType<ResourceReferenceType<SectionComponentEntryReferenceType>>>();
        descriptor.Field(x => x.EmptyReason);
        descriptor.Field(x => x.Section).Type<ListType<SectionComponentType>>();
    }
}

public class SectionComponentEntryReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SectionComponentEntryReference");
        descriptor.Type<ResourceType>();
    }
}

public class SectionComponentFocusReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SectionComponentFocusReference");
        descriptor.Type<ResourceType>();
    }
}

public class SectionComponentAuthorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SectionComponentAuthorReference");
        descriptor.Description(
            "Reference (Practitioner, PractitionerRole, Device, Patient, RelatedPerson, Organization)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<OrganizationType>();
    }
}

public class EventComponentType : ObjectType<EventComponent>
{
    protected override void Configure(IObjectTypeDescriptor<EventComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.Detail).Type<ResourceReferenceType<EventComponentDetailReferenceType>>();
    }
}

public class EventComponentDetailReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("EventComponentDetailReference");
        descriptor.Type<ResourceType>();
    }
}

public class CompositionRelatesToComponentType : ObjectType<RelatesToComponent>
{
    protected override void Configure(IObjectTypeDescriptor<RelatesToComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Code);
        descriptor.Field("targetIdentifier").Type<IdentifierType>()
            .Resolve(ctx => DataTypeResolvers.GetIdentifierValue(ctx.Parent<RelatesToComponent>().Target));

        descriptor.Field("targetReference")
            .Resolve(ctx => DataTypeResolvers.GetReferenceValue(ctx.Parent<RelatesToComponent>().Target))
            .Type<ResourceReferenceType<CompositionRelatesToTargetType>>();
    }
}

public class CompositionRelatesToTargetType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CompositionRelatesToTargetReference");
        descriptor.Type<CompositionType>();
    }
}

public class CompositionCustodianReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CompositionCustodianReference");
        descriptor.Type<OrganizationType>();
    }
}

public class CompositionAttesterComponentType : ObjectType<AttesterComponent>
{
    protected override void Configure(IObjectTypeDescriptor<AttesterComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Party).Type<ResourceReferenceType<CompositionAttesterPartyReferenceType>>();
        descriptor.Field(x => x.Mode);
        descriptor.Field(x => x.Time);
    }
}

public class CompositionAttesterPartyReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CompositionAttesterPartyReference");
        descriptor.Description("Reference (Patient, RelatedPerson, Practitioner, PractitionerRole, Organization)");

        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
    }
}

public class CompositionAuthorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CompositionAuthorReference");
        descriptor.Description("Reference(Practitioner|PractitionerRole|Device|Patient|RelatedPerson|Organization)");
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<OrganizationType>();
    }
}

public class CompositionEncounterReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CompositionEncounterReference");
        descriptor.Type<EncounterType>();
    }
}

public class CompositionSubjectReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("CompositionSubjectReference");
        descriptor.Type<ResourceType>();
    }
}