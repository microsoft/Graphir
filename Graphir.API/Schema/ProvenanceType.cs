using Hl7.Fhir.Model;

using HotChocolate.Types;

using Code = Hl7.Fhir.ElementModel.Types.Code;

namespace Graphir.API.Schema;

public class ProvenanceType : ObjectType<Provenance>
{
    protected override void Configure(IObjectTypeDescriptor<Provenance> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Id);
        descriptor.Field(p => p.Meta);
        descriptor.Field(p => p.Activity);
        // descriptor.Field(p => p.Occurred); TODO: Resolve based on type Period or a DateTime
        descriptor.Field(p => p.Reason);
        descriptor.Field(p => p.Recorded);
        descriptor.Field(p => p.Signature).Type<ListType<SignatureType>>();
        descriptor.Field(p => p.Text);
        descriptor.Field(p => p.Policy);
        descriptor.Field(p => p.Language);
        descriptor.Field(p => p.ImplicitRules);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.Contained);
        descriptor.Field(p => p.LanguageElement).Type<CodeType>();
        descriptor.Field(p => p.ImplicitRulesElement).Type<FhirUriType>();
        descriptor.Field(p => p.PolicyElement);
        descriptor.Field(p => p.RecordedElement).Type<InstantType>();
        descriptor.Field(p => p.ResourceBase);
        descriptor.Field(p => p.Location).Type<ResourceReferenceType<ProvenanceLocationReferenceType>>();
        descriptor.Field(p => p.Entity).Type<ListType<ProvenanceEntityComponentType>>();
        descriptor.Field(p => p.Agent).Type<ListType<AgentComponentType>>();
        descriptor.Field(p => p.Target).Type<ListType<ResourceReferenceType<ProvenanceTargetReferenceType>>>();
    }
}

public class InstantType : ObjectType<Instant>
{
    protected override void Configure(IObjectTypeDescriptor<Instant> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Value);
        descriptor.Field(p => p.Extension);
    }
}

public class CodeType : ObjectType<Code>
{
    protected override void Configure(IObjectTypeDescriptor<Code> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(p => p.Value);
        descriptor.Field(p => p.Display);
        descriptor.Field(p => p.System);
        descriptor.Field(p => p.Version);
    }
}

public class SignatureType : ObjectType<Signature>
{
    protected override void Configure(IObjectTypeDescriptor<Signature> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Type);
        descriptor.Field(p => p.When);
        descriptor.Field(p => p.Who);
        descriptor.Field(p => p.OnBehalfOf);
        descriptor.Field(p => p.TargetFormat);
        descriptor.Field(p => p.SigFormat);
        descriptor.Field(p => p.Data);
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.TypeName);
        descriptor.Field(p => p.ElementId);
    }
}

public class ProvenanceEntityComponentType : ObjectType<Provenance.EntityComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Provenance.EntityComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Role);
        descriptor.Field(p => p.Agent).Type<ListType<AgentComponentType>>();
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
        descriptor.Field(p => p.What).Type<ResourceReferenceType<WhatReferenceType>>();
        descriptor.Field(p => p.RoleElement).Type<StringType>(); //Must specify as StringType
        descriptor.Field(p => p.ElementId);
    }
}

public class WhatReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("IdentityOfEntityReference");

        descriptor.Type<ResourceType>();
    }
}

public class AgentComponentType : ObjectType<Provenance.AgentComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Provenance.AgentComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.Type);
        descriptor.Field(p => p.Role);
        descriptor.Field(p => p.Who)
            .Type<ResourceReferenceType<ProvenanceAgentWhoParticipatedReferenceType>>();
        descriptor.Field(p => p.OnBehalfOf)
            .Type<ResourceReferenceType<OnBehalfOfReferenceType>>();
        descriptor.Field(p => p.Extension);
        descriptor.Field(p => p.ModifierExtension);
    }
}

public class OnBehalfOfReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("OnBehalfOfReference");
        descriptor.Description(@"Who the agent is representing? Reference(Practitioner | PractitionerRole | RelatedPerson | Patient | Device | Organization)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PatientType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ProvenanceAgentWhoParticipatedReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("WhoParticipatedReference");
        descriptor.Description(@"Who participated? Reference(Practitioner | PractitionerRole | RelatedPerson | Patient | Device | Organization)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PatientType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ProvenanceTargetReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ProvenanceTargetReference");

        descriptor.Type<ResourceType>();
    }
}

public class ProvenanceLocationReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ProvenanceLocation");
        descriptor.Description("Where the activity occurred, if relevant");

        descriptor.Type<LocationType>();
    }
}