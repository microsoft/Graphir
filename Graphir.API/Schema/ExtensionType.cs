using Graphir.API.DataLoaders;

using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ExtensionType : ObjectType<Extension>
{
    protected override void Configure(IObjectTypeDescriptor<Extension> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Url);
        descriptor.Field(x => x.Extension);


        // primitive types
        descriptor.Field("valueBase64Binary")
            .Resolve(r => DataTypeResolvers.GetBase64BinaryValue(r.Parent<Extension>().Value));
        descriptor.Field("valueBoolean").Resolve(r => DataTypeResolvers.GetBooleanValue(r.Parent<Extension>().Value));
        descriptor.Field("valueCanonical")
            .Resolve(r => DataTypeResolvers.GetCanonicalValue(r.Parent<Extension>().Value));
        descriptor.Field("valueCode").Resolve(r => DataTypeResolvers.GetCodeValue(r.Parent<Extension>().Value));
        descriptor.Field("valueDate").Resolve(r => DataTypeResolvers.GetDateValue(r.Parent<Extension>().Value));
        descriptor.Field("valueDateTime").Resolve(r => DataTypeResolvers.GetDateTimeValue(r.Parent<Extension>().Value));
        descriptor.Field("valueDecimal").Resolve(r => DataTypeResolvers.GetDecimalValue(r.Parent<Extension>().Value));
        descriptor.Field("valueId").Resolve(r => DataTypeResolvers.GetIdValue(r.Parent<Extension>().Value));
        descriptor.Field("valueInstant").Resolve(r => DataTypeResolvers.GetInstantValue(r.Parent<Extension>().Value));
        descriptor.Field("valueInteger").Resolve(r => DataTypeResolvers.GetIntegerValue(r.Parent<Extension>().Value));
        descriptor.Field("valueInteger64")
            .Resolve(r => DataTypeResolvers.GetInteger64Value(r.Parent<Extension>().Value));
        descriptor.Field("valueMarkdown").Resolve(r => DataTypeResolvers.GetMarkdownValue(r.Parent<Extension>().Value));
        descriptor.Field("valueOid").Resolve(r => DataTypeResolvers.GetOidValue(r.Parent<Extension>().Value));
        descriptor.Field("valuePositiveInt")
            .Resolve(r => DataTypeResolvers.GetPositiveIntValue(r.Parent<Extension>().Value));
        descriptor.Field("valueString").Resolve(r => DataTypeResolvers.GetStringValue(r.Parent<Extension>().Value));
        descriptor.Field("valueTime").Resolve(r => DataTypeResolvers.GetTimeValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUnsignedInt")
            .Resolve(r => DataTypeResolvers.GetUnsignedIntValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUri").Resolve(r => DataTypeResolvers.GetUriValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUrl").Resolve(r => DataTypeResolvers.GetUrlValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUuid").Resolve(r => DataTypeResolvers.GetUuidValue(r.Parent<Extension>().Value));

        // Complex types
        descriptor.Field("valueAddress").Resolve(r => DataTypeResolvers.GetValue<Address>(r.Parent<Extension>().Value));
        descriptor.Field("valueAge").Resolve(r => DataTypeResolvers.GetValue<Age>(r.Parent<Extension>().Value));
        descriptor.Field("valueAnnotation")
            .Resolve(r => DataTypeResolvers.GetValue<Annotation>(r.Parent<Extension>().Value));
        descriptor.Field("valueAttachment")
            .Resolve(r => DataTypeResolvers.GetValue<Attachment>(r.Parent<Extension>().Value));
        descriptor.Field("valueCodeableConcept")
            .Resolve(r => DataTypeResolvers.GetValue<CodeableConcept>(r.Parent<Extension>().Value));
        descriptor.Field("valueCoding").Resolve(r => DataTypeResolvers.GetValue<Coding>(r.Parent<Extension>().Value));
        descriptor.Field("valueContactPoint")
            .Resolve(r => DataTypeResolvers.GetValue<ContactPoint>(r.Parent<Extension>().Value));
        descriptor.Field("valueCount").Resolve(r => DataTypeResolvers.GetValue<Count>(r.Parent<Extension>().Value));
        descriptor.Field("valueDistance")
            .Resolve(r => DataTypeResolvers.GetValue<Distance>(r.Parent<Extension>().Value));
        descriptor.Field("valueDuration")
            .Resolve(r => DataTypeResolvers.GetValue<Duration>(r.Parent<Extension>().Value));
        descriptor.Field("valueHumanName")
            .Resolve(r => DataTypeResolvers.GetValue<HumanName>(r.Parent<Extension>().Value));
        descriptor.Field("valueIdentifier")
            .Resolve(r => DataTypeResolvers.GetValue<Identifier>(r.Parent<Extension>().Value));
        descriptor.Field("valueMoney").Resolve(r => DataTypeResolvers.GetValue<Money>(r.Parent<Extension>().Value));
        descriptor.Field("valuePeriod").Resolve(r => DataTypeResolvers.GetValue<Period>(r.Parent<Extension>().Value));
        descriptor.Field("valueQuantity")
            .Resolve(r => DataTypeResolvers.GetValue<Quantity>(r.Parent<Extension>().Value));
        descriptor.Field("valueRange").Resolve(r => DataTypeResolvers.GetValue<Range>(r.Parent<Extension>().Value));
        descriptor.Field("valueRatio").Resolve(r => DataTypeResolvers.GetValue<Ratio>(r.Parent<Extension>().Value));
        descriptor.Field("valueSampledData")
            .Resolve(r => DataTypeResolvers.GetValue<SampledData>(r.Parent<Extension>().Value));
        descriptor.Field("valueSignature")
            .Resolve(r => DataTypeResolvers.GetValue<Signature>(r.Parent<Extension>().Value));
        descriptor.Field("valueTiming").Resolve(r => DataTypeResolvers.GetValue<Timing>(r.Parent<Extension>().Value));
        descriptor.Field("valueContactDetail")
            .Resolve(r => DataTypeResolvers.GetValue<ContactDetail>(r.Parent<Extension>().Value));
        descriptor.Field("valueContributor")
            .Resolve(r => DataTypeResolvers.GetValue<Contributor>(r.Parent<Extension>().Value));
        descriptor.Field("valueDataRequirement")
            .Resolve(r => DataTypeResolvers.GetValue<DataRequirement>(r.Parent<Extension>().Value));
        descriptor.Field("valueExpression")
            .Resolve(r => DataTypeResolvers.GetValue<Expression>(r.Parent<Extension>().Value));
        descriptor.Field("valueParameterDefinition").Resolve(r =>
            DataTypeResolvers.GetValue<ParameterDefinition>(r.Parent<Extension>().Value));
        descriptor.Field("valueRelatedArtifact")
            .Resolve(r => DataTypeResolvers.GetValue<RelatedArtifact>(r.Parent<Extension>().Value));
        descriptor.Field("valueTriggerDefinition")
            .Resolve(r => DataTypeResolvers.GetValue<TriggerDefinition>(r.Parent<Extension>().Value));
        descriptor.Field("valueUsageContext")
            .Resolve(r => DataTypeResolvers.GetValue<UsageContext>(r.Parent<Extension>().Value));
        descriptor.Field("valueDosage").Resolve(r => DataTypeResolvers.GetValue<Dosage>(r.Parent<Extension>().Value));
        descriptor.Field("valueMeta").Resolve(r => DataTypeResolvers.GetValue<Meta>(r.Parent<Extension>().Value));
    }
}