using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

using static Hl7.Fhir.Model.Contract;

namespace Graphir.API.Schema;

public class ContractType : ObjectType<Contract>
{
    protected override void Configure(IObjectTypeDescriptor<Contract> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.Id);
        descriptor.Field(t => t.Meta);
        descriptor.Field(t => t.Issued);
        descriptor.Field(t => t.Applies);
        descriptor.Field(t => t.Subject).Type<ListType<ResourceReferenceType<ContractSubjectReferenceType>>>();
        descriptor.Field(t => t.Authority).Type<ListType<ResourceReferenceType<ContractAuthorityReferenceType>>>();
        descriptor.Field(t => t.Domain).Type<ListType<ResourceReferenceType<ContractDomainReferenceType>>>();
        descriptor.Field(t => t.Type);
        descriptor.Field(t => t.SubType);
        descriptor.Field(t => t.Legal).Type<ListType<ContractLegalLanguageComponentType>>();
        descriptor.Field(t => t.Name);
        descriptor.Field(t => t.Title);
        descriptor.Field(t => t.Signer).Type<ListType<ContractSignerComponentType>>();
        descriptor.Field(t => t.Friendly).Type<ListType<ContractFriendlyLanguageComponentType>>();
        descriptor.Field(t => t.Site).Type<ListType<ResourceReferenceType<ContractSiteReferenceType>>>();
        descriptor.Field(t => t.ContentDefinition).Type<ContractContentDefinitionComponentType>();
        descriptor.Field(t => t.Term).Type<ListType<ContractTermComponentType>>();
        descriptor.Field(t => t.LegalState);
        descriptor.Field(t => t.InstantiatesCanonical).Type<ResourceReferenceType<ContractInstantiatesCanonicalReferenceType>>()
            .Type<ResourceReferenceType<ContractInstantiatesCanonicalReferenceType>>();
        descriptor.Field(t => t.InstantiatesUri);
        descriptor.Field(t => t.ContentDerivative);
        descriptor.Field(t => t.Subtitle);
        descriptor.Field(t => t.Alias);
        descriptor.Field(t => t.Author).Type<ResourceReferenceType<ContractAuthorReferenceType>>();
        descriptor.Field(t => t.Scope);
        descriptor.Field("topicCodeableConcept")
            .Resolve(t => DataTypeResolvers.GetValue<CodeableConcept>(t.Parent<Contract>().Topic));
        descriptor.Field("topicReference")
            .Resolve(t => DataTypeResolvers.GetValue<ResourceReference>(t.Parent<Contract>().Topic))
            .Type<ResourceReferenceType<ContractTopicReferenceType>>();
        descriptor.Field(t => t.Version);
        descriptor.Field(t => t.Contained);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Status);
        descriptor.Field(t => t.Identifier);
    }
}

public class ContractTopicReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractTopicReference");
        descriptor.Type<ResourceType>();
    }
}

public class ContractAuthorReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractAuthorReference");
        descriptor.Description("Reference(Patient | Practitioner | PractitionerRole | Organization)");

        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ContractInstantiatesCanonicalReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractInstantiatesCanonicalReference");

        descriptor.Type<ContractType>();
    }
}

public class ContractTermComponentType : ObjectType<TermComponent>
{
    protected override void Configure(IObjectTypeDescriptor<TermComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Issued);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.IssuedElement).Type<DateTimeType>(); 
        descriptor.Field(x => x.Applies);
        
        descriptor.Field("topicCodeableConcept").Resolve(t =>
            DataTypeResolvers.GetValue<CodeableConcept>(t.Parent<TermComponent>().Topic));
        descriptor.Field("topicReference").Resolve(t =>
                DataTypeResolvers.GetValue<ResourceReference>(t.Parent<TermComponent>().Topic))
            .Type<ResourceReferenceType<TermComponentTopicReferenceType>>();
        
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.SubType);
        descriptor.Field(x => x.TextElement).Type<StringType>(); 
        descriptor.Field(x => x.SecurityLabel).Type<ListType<ContractSecurityLabelComponentType>>(); 
        descriptor.Field(x => x.Group).Type<ListType<ContractTermComponentType>>();
        descriptor.Field(x => x.Offer).Type<ContractOfferComponentType>();
        descriptor.Field(x => x.Asset).Type<ListType<ContractAssetComponentType>>();
        descriptor.Field(x => x.Action).Type<ListType<ContractActionComponentType>>();
    }
}

public class ContractActionComponentType : ObjectType<ActionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ActionComponent> descriptor)
    {
        descriptor.Name("ContractActionComponent");
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.DoNotPerform);
        descriptor.Field(t => t.Type);
        descriptor.Field(t => t.Subject).Type<ListType<ResourceReferenceType<ContractSubjectReferenceType>>>();
        descriptor.Field(t => t.Intent);
        descriptor.Field(t => t.LinkId);
        descriptor.Field(t => t.Status);
        descriptor.Field(t => t.Context).Type<ResourceReferenceType<ContractContextReferenceType>>();
        descriptor.Field(t => t.ContextLinkId);
        
        descriptor.Field("occurrenceDateTime").Resolve(t =>
            DataTypeResolvers.GetDateTimeValue(t.Parent<ActionComponent>().Occurrence));
        descriptor.Field("occurrencePeriod").Resolve(t =>
            DataTypeResolvers.GetPeriodValue(t.Parent<ActionComponent>().Occurrence));
        descriptor.Field("occurrenceTiming").Resolve(t =>
            DataTypeResolvers.GetTimeValue(t.Parent<ActionComponent>().Occurrence));

        descriptor.Field(t => t.Requester).Type<ListType<ResourceReferenceType<ContractRequesterComponentType>>>();
        descriptor.Field(t => t.PerformerType);
        descriptor.Field(t => t.PerformerRole);
        descriptor.Field(t => t.Performer).Type<ResourceReferenceType<ContractPerformerReferenceType>>();
        descriptor.Field(t => t.ReasonCode);
        descriptor.Field(t => t.ReasonReference).Type<ListType<ResourceReferenceType<ContractReasonReferenceType>>>();
        descriptor.Field(t => t.Reason);
        descriptor.Field(t => t.Note);
        descriptor.Field(t => t.SecurityLabelNumber);
    }
}

public class ContractReasonReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractReasonReference");
        descriptor.Description("Reference(Condition | Observation | DiagnosticReport | DocumentReference | Questionnaire | QuestionnaireResponse)");
        
        descriptor.Type<ConditionType>();
        descriptor.Type<ObservationType>();
        descriptor.Type<DiagnosticReportType>();
        descriptor.Type<DocumentReferenceType>();
        descriptor.Type<QuestionnaireType>();
        descriptor.Type<QuestionnaireResponseType>();
    }
}

public class ContractPerformerReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractPerformerReference");
        descriptor.Description("Reference(RelatedPerson | Patient | Practitioner | PractitionerRole | CareTeam | Device | Substance | Organization | Location)");
        
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<CareTeamType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<SubstanceType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<LocationType>();
    }
}

public class ContractRequesterComponentType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractRequesterComponent");
        descriptor.Description("Reference(Patient | RelatedPerson | Practitioner | PractitionerRole | Device | Group | Organization)");
        
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<GroupType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ContractContextReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractContextReference");
        descriptor.Description("Reference(Encounter | EpisodeOfCare)");

        descriptor.Type<EncounterType>();
        descriptor.Type<EpisodeOfCareType>();
    }
}

public class ContractAssetComponentType : ObjectType<ContractAssetComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ContractAssetComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Scope);
        descriptor.Field(t => t.Type);
        descriptor.Field(t => t.TypeReference).Type<ListType<ResourceReferenceType<ContractTypeReferenceType>>>();
        descriptor.Field(t => t.Subtype);
        descriptor.Field(t => t.Relationship);
        descriptor.Field(t => t.Context).Type<ListType<ContractContextComponentType>>();
        descriptor.Field(t => t.ConditionElement);
        descriptor.Field(t => t.PeriodType);
        descriptor.Field(t => t.Period);
        descriptor.Field(t => t.UsePeriod);
        descriptor.Field(t => t.TextElement);
        descriptor.Field(t => t.LinkIdElement);
        descriptor.Field(t => t.Answer).Type<ListType<ContractAssetAnswerComponentType>>();
        descriptor.Field(t => t.SecurityLabelNumberElement).Type<ListType<UnsignedIntType>>();
        descriptor.Field(t => t.ValuedItem).Type<ListType<ContractAssetValuedItemComponentType>>();
    }
}

public class UnsignedIntType : ObjectType<UnsignedInt>
{
    protected override void Configure(IObjectTypeDescriptor<UnsignedInt> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(t => t.Value);
    }
}

public class ContractAssetValuedItemComponentType : ObjectType<ValuedItemComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ValuedItemComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Net).Type<MoneyType>();
        descriptor.Field(t => t.Payment);
        descriptor.Field(t => t.PaymentElement).Type<StringType>();
        descriptor.Field(t => t.PaymentDate);
        descriptor.Field(t => t.PaymentDateElement).Type<DateTimeType>();
        descriptor.Field(t => t.Responsible).Type<ResourceReferenceType<ContractAssetValuedItemComponentReferenceType>>();
        descriptor.Field(t => t.LinkId);
        descriptor.Field(t => t.LinkIdElement).Type<ListType<StringType>>();
        descriptor.Field(t => t.Recipient).Type<ResourceReferenceType<ContractAssetValuedItemRecipientComponentType>>();
        descriptor.Field(t => t.SecurityLabelNumber);
        descriptor.Field(t => t.SecurityLabelNumberElement);
        descriptor.Field(t => t.Factor);
        descriptor.Field(t => t.FactorElement).Type<DecimalType>();
        descriptor.Field(t => t.Points);
        descriptor.Field(t => t.PointsElement).Type<DecimalType>();
        descriptor.Field(t => t.UnitPrice).Type<MoneyType>();
        descriptor.Field(t => t.Quantity);
        descriptor.Field(t => t.EffectiveTime);
        descriptor.Field(t => t.EffectiveTimeElement).Type<DateTimeType>();
        descriptor.Field(t => t.Identifier);
        descriptor.Field("entityCodeableConcept")
            .Resolve(t=>DataTypeResolvers.GetValue<CodeableConcept>(t.Parent<ValuedItemComponent>().Entity));
        descriptor.Field("entityReference")
            .Resolve(t=>DataTypeResolvers.GetValue<ResourceReference>(t.Parent<ValuedItemComponent>().Entity))
            .Type<ResourceReferenceType<ContractAssetValuedItemReferenceType>>();
    }
}

public class ContractAssetValuedItemComponentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractAssetValuedItemComponentReference");
        descriptor.Description("Reference(Organization | Patient | Practitioner | PractitionerRole | RelatedPerson)");
        
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class ContractAssetValuedItemRecipientComponentType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractAssetValuedItemRecipientComponent");
        descriptor.Description("Reference(Organization | Patient | Practitioner | PractitionerRole | RelatedPerson)");
        
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class ContractAssetValuedItemReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractAssetValuedItemReference");
        descriptor.Type<ResourceType>();
    }
}

public class ContractAssetAnswerComponentType : ObjectType<AnswerComponent>
{
    protected override void Configure(IObjectTypeDescriptor<AnswerComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.TypeName);
        
        descriptor.Field("valueBoolean")
            .Resolve(t => DataTypeResolvers.GetBooleanValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueDecimal")
            .Resolve(t => DataTypeResolvers.GetDecimalValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueInteger")
            .Resolve(t => DataTypeResolvers.GetIntegerValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueDate").
            Resolve(t => DataTypeResolvers.GetDateValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueDateTime")
            .Resolve(t => DataTypeResolvers.GetDateTimeValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueTime")
            .Resolve(t => DataTypeResolvers.GetTimeValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueString")
            .Resolve(t => DataTypeResolvers.GetStringValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueUri")
            .Resolve(t => DataTypeResolvers.GetUriValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueAttachment")
            .Resolve(t => DataTypeResolvers.GetAttachmentValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueCoding")
            .Resolve(t => DataTypeResolvers.GetCodeValue(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueQuantity")
            .Resolve(t => DataTypeResolvers.GetSimpleQuantity(t.Parent<AnswerComponent>().Value));
        descriptor.Field("valueReference")
            .Resolve(t => DataTypeResolvers.GetReferenceValue(t.Parent<AnswerComponent>().Value))
            .Type<ResourceReferenceType<ContractAssetAnswerValueReferenceType>>();
    }
}

public class ContractAssetAnswerValueReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractAssetAnswerValueReference");
        descriptor.Type<ResourceType>();
    }
}

public class ContractContextComponentType : ObjectType<AssetContextComponent>
{
    protected override void Configure(IObjectTypeDescriptor<AssetContextComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Reference).Type<ResourceReferenceType<ContractContextComponentReferenceType>>();
        descriptor.Field(t => t.Code);
        descriptor.Field(t => t.TextElement);
        descriptor.Field(t => t.Text);
        descriptor.Field(t => t.TypeName);
    }
}

public class ContractContextComponentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractContextComponentReference");

        descriptor.Type<ResourceType>();
    }
}

public class ContractTypeReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractTypeReference");

        descriptor.Type<ResourceType>();
    }
}

public class ContractOfferComponentType : ObjectType<ContractOfferComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ContractOfferComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Identifier);
        descriptor.Field(t => t.Party).Type<ListType<ContractPartyComponentType>>();
        descriptor.Field(t => t.Topic).Type<ResourceReferenceType<ContractOfferTopicReferenceType>>();
        descriptor.Field(t => t.Type);
        descriptor.Field(t => t.Decision);
        descriptor.Field(t => t.DecisionMode);
        descriptor.Field(t => t.Answer).Type<ContractAssetAnswerComponentType>();
        descriptor.Field(t => t.TextElement).Type<StringType>();
        descriptor.Field(t => t.LinkId);
        descriptor.Field(t => t.SecurityLabelNumber);
    }
}

public class ContractOfferTopicReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractOfferTopicReference");
        descriptor.Type<ResourceType>();
    }
}

public class ContractPartyComponentType : ObjectType<ContractPartyComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ContractPartyComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Reference).Type<ListType<ResourceReferenceType<ContractPartyComponentReferenceType>>>();
        descriptor.Field(t => t.Role);
    }
}

public class ContractPartyComponentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractPartyComponentReference");
        descriptor.Description("Reference(Patient | RelatedPerson | Practitioner | PractitionerRole | Device | Group | Organization)");

        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<GroupType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ContractSecurityLabelComponentType : ObjectType<SecurityLabelComponent>
{
    protected override void Configure(IObjectTypeDescriptor<SecurityLabelComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Number);
        descriptor.Field(t => t.Classification).Type<CodingType>();
        descriptor.Field(t => t.Category).Type<ListType<CodingType>>();
        descriptor.Field(t => t.Control).Type<ListType<CodingType>>();
    }
}

public class TermComponentTopicReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("TermComponentTopicReference");
        descriptor.Type<ResourceType>();
    }
}

public class ContractContentDefinitionComponentType : ObjectType<ContentDefinitionComponent>
{
    protected override void Configure(IObjectTypeDescriptor<ContentDefinitionComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Type);
        descriptor.Field(t => t.SubType);
        descriptor.Field(t => t.Publisher).Type<ResourceReferenceType<ContractContentDefinitionComponentReferenceType>>();
        descriptor.Field(t => t.PublicationDate);
        descriptor.Field(t => t.PublicationStatus);
        descriptor.Field(t => t.Copyright);
    }
}

public class ContractContentDefinitionComponentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractContentDefinitionComponentReference");
        descriptor.Description("Reference(Practitioner | PractitionerRole | Organization)");

        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
    }
}

public class ContractSiteReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractSiteReference");
        descriptor.Type<LocationType>();
    }
}

public class ContractFriendlyLanguageComponentType : ObjectType<FriendlyLanguageComponent>
{
    protected override void Configure(IObjectTypeDescriptor<FriendlyLanguageComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field("contentAttachment").Resolve(t => DataTypeResolvers
            .GetValue<Attachment>(t.Parent<FriendlyLanguageComponent>().Content));
        descriptor.Field("contentReference").Resolve(t => DataTypeResolvers
                .GetValue<ResourceReference>(t.Parent<FriendlyLanguageComponent>().Content))
            .Type<ResourceReferenceType<ContractFriendlyLanguageContentReferenceType>>();
    }
}

public class ContractFriendlyLanguageContentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractFriendlyLanguageContentReference");
        descriptor.Description("Reference(Composition | DocumentReference | QuestionnaireResponse)");
        
        descriptor.Type<DocumentReferenceType>();
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<CompositionType>(); 
    }
}

public class ContractSignerComponentType : ObjectType<SignatoryComponent>
{
    protected override void Configure(IObjectTypeDescriptor<SignatoryComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
        descriptor.Field(t => t.Type);
        descriptor.Field(t => t.Party).Type<ResourceReferenceType<ContractSignerPartyReferenceType>>();
        descriptor.Field(t => t.Signature); 
    }
}

public class ContractSignerPartyReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractSignerPartyReference");
        descriptor.Description("Reference(Organization | Patient | Practitioner | PractitionerRole | RelatedPerson)");
        
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<RelatedPersonType>();
    }
}

public class ContractLegalLanguageComponentType : ObjectType<LegalLanguageComponent>
{
    protected override void Configure(IObjectTypeDescriptor<LegalLanguageComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.ElementId);
        descriptor.Field("contentAttachment").Resolve(t => DataTypeResolvers
            .GetValue<Attachment>(t.Parent<LegalLanguageComponent>().Content));

        descriptor.Field("contentReference").Resolve(t => DataTypeResolvers
            .GetValue<ResourceReference>(t.Parent<LegalLanguageComponent>().Content))
            .Type<ResourceReferenceType<LegalLanguageContentReferenceType>>();
        
        descriptor.Field(t => t.Extension);
        descriptor.Field(t => t.ModifierExtension);
    }
}

public class LegalLanguageContentReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("LegalLanguageContentReference");
        descriptor.Description("Reference(Composition | DocumentReference | QuestionnaireResponse)");
        
        descriptor.Type<DocumentReferenceType>();
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<CompositionType>(); 
    }
}

public class ContractDomainReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractDomainReference");
        descriptor.Type<LocationType>();
    }
}

public class ContractAuthorityReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractAuthorityReference");
        descriptor.Type<OrganizationType>();
    }
}

public class ContractSubjectReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ContractSubjectReference");
        descriptor.Type<ResourceType>();
    }
}