using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class AllergyIntoleranceType : ObjectType<AllergyIntolerance>
{
    // TODO: finish allergyintolerance
    protected override void Configure(IObjectTypeDescriptor<AllergyIntolerance> descriptor)
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
        descriptor.Field(x => x.ClinicalStatus);
        descriptor.Field(x => x.VerificationStatus);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Criticality);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Patient).Type<ResourceReferenceType<PatientReferenceType>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<EncounterReferenceType>>();
        descriptor.Field("onsetDateTime")
            .Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<AllergyIntolerance>().Onset));
        descriptor.Field("onsetAge")
            .Resolve(r => DataTypeResolvers.GetValue<Age>(r.Parent<AllergyIntolerance>().Onset));
        descriptor.Field("onsetPeriod")
            .Resolve(r => DataTypeResolvers.GetValue<Period>(r.Parent<AllergyIntolerance>().Onset));
        descriptor.Field("onsetRange")
            .Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<AllergyIntolerance>().Onset));
        descriptor.Field("onsetString")
            .Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<AllergyIntolerance>().Onset));
        descriptor.Field(x => x.RecordedDate);
        descriptor.Field(x => x.Recorder).Type<ResourceReferenceType<RecorderReferenceType>>();
        descriptor.Field(x => x.Asserter).Type<ResourceReferenceType<RecorderReferenceType>>();
        descriptor.Field(x => x.LastOccurrence);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.Reaction).Type<ListType<AllergyIntoleranceReactionType>>();
    }

    private class AllergyIntoleranceReactionType : ObjectType<AllergyIntolerance.ReactionComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<AllergyIntolerance.ReactionComponent> descriptor)
        {
            descriptor.Name("AllergyIntoleranceReaction");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.ElementId);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
            descriptor.Field(x => x.Substance);
            descriptor.Field(x => x.Manifestation);
            descriptor.Field(x => x.Description);
            descriptor.Field(x => x.Onset);
            descriptor.Field(x => x.Severity);
            descriptor.Field(x => x.ExposureRoute);
            descriptor.Field(x => x.Note);
        }
    }
}