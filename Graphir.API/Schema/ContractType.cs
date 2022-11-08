using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ContractType : ObjectType<Contract>
{
    protected override void Configure(IObjectTypeDescriptor<Contract> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);

        descriptor.Field(x => x.Term).Type<ListType<ContractTermType>>();
        descriptor.Field("legallyBindingAttachment")
            .Resolve(r => DataTypeResolvers.GetValue<Attachment>(r.Parent<Contract>().LegallyBinding));
    }

    private class ContractTermType : ObjectType<Contract.TermComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Contract.TermComponent> descriptor)
        {
            descriptor.Name("ContractTerm");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.ElementId);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Identifier);
            descriptor.Field(x => x.Issued);
            descriptor.Field(x => x.Applies);
            descriptor.Field("topicCodeableConcept")
                .Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Contract.TermComponent>().Topic));
            descriptor.Field("topicReference")
                .Resolve(r => DataTypeResolvers.GetReferenceValue(r.Parent<Contract.TermComponent>().Topic));
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.SubType);
            descriptor.Field(x => x.Text);
            descriptor.Field(x => x.SecurityLabel).Type<ListType<ContractTermSecurityLabelType>>();
            descriptor.Field(x => x.Offer).Type<ContractTermOfferType>();
            descriptor.Field(x => x.Asset).Type<ListType<ContractTermAssetType>>();
            descriptor.Field(x => x.Action).Type<ListType<ContractTermActionType>>();
            descriptor.Field(x => x.Group).Type<ListType<ContractTermType>>();
        }

        private class ContractTermSecurityLabelType : ObjectType<Contract.SecurityLabelComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Contract.SecurityLabelComponent> descriptor)
            {
                descriptor.Name("ContractTermSecurityLabel");
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.ElementId);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Number);
                descriptor.Field(x => x.Classification);
                descriptor.Field(x => x.Category);
                descriptor.Field(x => x.Control);
            }
        }

        private class ContractTermOfferType : ObjectType<Contract.ContractOfferComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Contract.ContractOfferComponent> descriptor)
            {
                descriptor.Name("ContractTermOffer");
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.ElementId);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Identifier);
                descriptor.Field(x => x.Party).Type<ListType<ContractTermOfferPartyType>>();
                descriptor.Field(x => x.Topic).Type<ResourceReferenceType<AnyReferenceType>>();
                descriptor.Field(x => x.Type);
                descriptor.Field(x => x.Decision);
                descriptor.Field(x => x.DecisionMode);
                descriptor.Field(x => x.Answer).Type<ListType<ContractTermOfferAnswerType>>();
                descriptor.Field(x => x.Text);
                descriptor.Field(x => x.LinkId);
                descriptor.Field(x => x.SecurityLabelNumber);
            }

            private class ContractTermOfferPartyType : ObjectType<Contract.ContractPartyComponent>
            {
                protected override void Configure(IObjectTypeDescriptor<Contract.ContractPartyComponent> descriptor)
                {
                    descriptor.Name("ContractTermOfferPartyType");
                    descriptor.BindFieldsExplicitly();

                    descriptor.Field(x => x.ElementId);
                    descriptor.Field(x => x.Extension);
                    descriptor.Field(x => x.ModifierExtension);
                    descriptor.Field(x => x.Reference)
                        .Type<ListType<ResourceReferenceType<ContractTermOfferPartyReferenceType>>>();
                    descriptor.Field(x => x.Role);
                }

                private class ContractTermOfferPartyReferenceType : UnionType
                {
                    protected override void Configure(IUnionTypeDescriptor descriptor)
                    {
                        descriptor.Description(
                            "Reference(Patient | RelatedPerson | Practitioner | PractitionerRole | Device | Group | Organization)");
                        descriptor.Type<PatientType>();
                        descriptor.Type<RelatedPersonType>();
                        descriptor.Type<PractitionerType>();
                        descriptor.Type<PractitionerRoleType>();
                        descriptor.Type<DeviceType>();
                        descriptor.Type<GroupType>();
                        descriptor.Type<OrganizationType>();
                    }
                }
            }
        }

        private class ContractTermAssetType : ObjectType<Contract.ContractAssetComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Contract.ContractAssetComponent> descriptor)
            {
                descriptor.Name("ContractTermAsset");
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.ElementId);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Scope);
                descriptor.Field(x => x.Type);
                descriptor.Field(x => x.TypeReference).Type<ListType<ResourceReferenceType<AnyReferenceType>>>();
                descriptor.Field(x => x.Subtype);
                descriptor.Field(x => x.Relationship);
                descriptor.Field(x => x.Context).Type<ListType<ContractTermAssetType>>();
                descriptor.Field(x => x.Condition);
                descriptor.Field(x => x.Period);
                descriptor.Field(x => x.UsePeriod);
                descriptor.Field(x => x.Text);
                descriptor.Field(x => x.LinkId);
                descriptor.Field(x => x.Answer).Type<ListType<ContractTermOfferAnswerType>>();
                descriptor.Field(x => x.SecurityLabelNumber);
                descriptor.Field(x => x.ValuedItem).Type<ListType<ContractTermAssetValuedItemType>>();
            }
        }

        private class ContractTermOfferAnswerType : ObjectType<Contract.AnswerComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Contract.AnswerComponent> descriptor)
            {
                descriptor.Name("ContractTermOfferAnswer");
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.ElementId);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field("valueBoolean")
                    .Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueDecimal")
                    .Resolve(r => DataTypeResolvers.GetDecimalValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueInteger")
                    .Resolve(r => DataTypeResolvers.GetIntegerValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueDate")
                    .Resolve(r => DataTypeResolvers.GetDateValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueDateTime")
                    .Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueTime")
                    .Resolve(r => DataTypeResolvers.GetTimeValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueString")
                    .Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueUri")
                    .Resolve(r => DataTypeResolvers.GetUriValue(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueAttachment")
                    .Resolve(r => DataTypeResolvers.GetValue<Attachment>(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueCoding")
                    .Resolve(r => DataTypeResolvers.GetValue<Coding>(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueQuantity")
                    .Resolve(r => DataTypeResolvers.GetValue<Quantity>(r.Parent<Contract.AnswerComponent>().Value));
                descriptor.Field("valueReference")
                    .Resolve(r => DataTypeResolvers.GetReferenceValue(r.Parent<Contract.AnswerComponent>().Value));
            }
        }

        private class ContractTermAssetValuedItemType : ObjectType<Contract.ValuedItemComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Contract.ValuedItemComponent> descriptor)
            {
                descriptor.Name("ContractTermAssetValuedItemType");
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.ElementId);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field("entityCodeableConcept")
                    .Resolve(r =>
                        DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Contract.ValuedItemComponent>().Entity));
                descriptor.Field("entityReference")
                    .Resolve(r => DataTypeResolvers.GetReferenceValue(r.Parent<Contract.ValuedItemComponent>().Entity));
                descriptor.Field(x => x.Identifier);
                descriptor.Field(x => x.EffectiveTime);
                descriptor.Field(x => x.Quantity);
                descriptor.Field(x => x.UnitPrice);
                descriptor.Field(x => x.Factor);
                descriptor.Field(x => x.Points);
                descriptor.Field(x => x.Net);
                descriptor.Field(x => x.Payment);
                descriptor.Field(x => x.PaymentDate);
                descriptor.Field(x => x.Responsible);
                descriptor.Field(x => x.Recipient).Type<ResourceReferenceType<AnyReferenceType>>();
                descriptor.Field(x => x.LinkId);
                descriptor.Field(x => x.SecurityLabelNumber);
            }
        }

        private class ContractTermActionType : ObjectType<Contract.ActionComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Contract.ActionComponent> descriptor)
            {
                descriptor.Name("ContractTermAction");
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.ElementId);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.DoNotPerform);
                descriptor.Field(x => x.Type);
                descriptor.Field(x => x.Subject).Type<ListType<ContractTermActionSubjectType>>();
                descriptor.Field(x => x.Intent);
                descriptor.Field(x => x.LinkId);
                descriptor.Field(x => x.Status);
                descriptor.Field(x => x.Context).Type<ResourceReferenceType<ContractTermActionContextReferenceType>>();
                descriptor.Field(x => x.ContextLinkId);
                descriptor.Field("occurrenceDateTime")
                    .Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Contract.ActionComponent>().Occurrence));
                descriptor.Field("occurrencePeriod")
                    .Resolve(r => DataTypeResolvers.GetValue<Period>(r.Parent<Contract.ActionComponent>().Occurrence));
                descriptor.Field("occurrenceTiming")
                    .Resolve(r => DataTypeResolvers.GetValue<Timing>(r.Parent<Contract.ActionComponent>().Occurrence));
                descriptor.Field(x => x.Requester).Type<ListType<ResourceReferenceType<RequesterReferenceType>>>();
                descriptor.Field(x => x.RequesterLinkId);
                descriptor.Field(x => x.PerformerType);
                descriptor.Field(x => x.PerformerRole);
                descriptor.Field(x => x.Performer)
                    .Type<ResourceReferenceType<ContractTermActionPerformerReferenceType>>();
                descriptor.Field(x => x.PerformerLinkId);
                descriptor.Field(x => x.Reason);
                descriptor.Field(x => x.ReasonLinkId);
                descriptor.Field(x => x.Note);
                descriptor.Field(x => x.SecurityLabelNumber);
            }

            private class ContractTermActionContextReferenceType : UnionType
            {
                protected override void Configure(IUnionTypeDescriptor descriptor)
                {
                    descriptor.Description("Reference(Encounter | EpisodeOfCare)");
                    descriptor.Type<EncounterType>();
                    descriptor.Type<EpisodeOfCareType>();
                }
            }

            private class ContractTermActionPerformerReferenceType : UnionType
            {
                protected override void Configure(IUnionTypeDescriptor descriptor)
                {
                    descriptor.Description(
                        "Reference(RelatedPerson | Patient | Practitioner | PractitionerRole | CareTeam | Device | Substance | Organization | Location)");
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
        }

        private class ContractTermActionSubjectType : ObjectType<Contract.ActionSubjectComponent>
        {
            protected override void Configure(IObjectTypeDescriptor<Contract.ActionSubjectComponent> descriptor)
            {
                descriptor.Name("ContractTermActionSubject");
                descriptor.BindFieldsExplicitly();

                descriptor.Field(x => x.ElementId);
                descriptor.Field(x => x.Extension);
                descriptor.Field(x => x.ModifierExtension);
                descriptor.Field(x => x.Reference)
                    .Type<ListType<ResourceReferenceType<ContractActionSubjectReferenceType>>>();
                descriptor.Field(x => x.Role);
            }

            private class ContractActionSubjectReferenceType : UnionType
            {
                protected override void Configure(IUnionTypeDescriptor descriptor)
                {
                    descriptor.Description(
                        "Reference(Patient | RelatedPerson | Practitioner | PractitionerRole | Device | Group | Organization)");
                    descriptor.Type<PatientType>();
                    descriptor.Type<RelatedPersonType>();
                    descriptor.Type<PractitionerType>();
                    descriptor.Type<PractitionerRoleType>();
                    descriptor.Type<DeviceType>();
                    descriptor.Type<GroupType>();
                    descriptor.Type<OrganizationType>();
                }
            }
        }
    }
}