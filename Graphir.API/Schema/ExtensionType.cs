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
        descriptor.Field("valueBase64Binary").Resolve(r => ValueResolvers.GetBase64BinaryValue(r.Parent<Extension>().Value));
        descriptor.Field("valueBoolean").Resolve(r => ValueResolvers.GetBooleanValue(r.Parent<Extension>().Value));
        descriptor.Field("valueCanonical").Resolve(r => ValueResolvers.GetCanonicalValue(r.Parent<Extension>().Value));
        descriptor.Field("valueCode").Resolve(r => ValueResolvers.GetCodeValue(r.Parent<Extension>().Value));
        descriptor.Field("valueDate").Resolve(r => ValueResolvers.GetDateValue(r.Parent<Extension>().Value));
        descriptor.Field("valueDateTime").Resolve(r => ValueResolvers.GetDateTimeValue(r.Parent<Extension>().Value));
        descriptor.Field("valueDecimal").Resolve(r => ValueResolvers.GetDecimalValue(r.Parent<Extension>().Value));
        descriptor.Field("valueId").Resolve(r => ValueResolvers.GetIdValue(r.Parent<Extension>().Value));
        descriptor.Field("valueInstant").Resolve(r => ValueResolvers.GetInstantValue(r.Parent<Extension>().Value));
        descriptor.Field("valueInteger").Resolve(r => ValueResolvers.GetIntegerValue(r.Parent<Extension>().Value));
        descriptor.Field("valueInteger64").Resolve(r => ValueResolvers.GetInteger64Value(r.Parent<Extension>().Value));
        descriptor.Field("valueMarkdown").Resolve(r => ValueResolvers.GetMarkdownValue(r.Parent<Extension>().Value));
        descriptor.Field("valueOid").Resolve(r => ValueResolvers.GetOidValue(r.Parent<Extension>().Value));
        descriptor.Field("valuePositiveInt").Resolve(r => ValueResolvers.GetPositiveIntValue(r.Parent<Extension>().Value));
        descriptor.Field("valueString").Resolve(r => ValueResolvers.GetStringValue(r.Parent<Extension>().Value));
        descriptor.Field("valueTime").Resolve(r => ValueResolvers.GetTimeValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUnsignedInt").Resolve(r => ValueResolvers.GetUnsignedIntValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUri").Resolve(r => ValueResolvers.GetUriValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUrl").Resolve(r => ValueResolvers.GetUrlValue(r.Parent<Extension>().Value));
        descriptor.Field("valueUuid").Resolve(r => ValueResolvers.GetUuidValue(r.Parent<Extension>().Value));
        
        // Complex types
        descriptor.Field("valueAddress").Resolve(r => ValueResolvers.GetValue<Address>(r.Parent<Extension>().Value));
        descriptor.Field("valueAge").Resolve(r => ValueResolvers.GetValue<Age>(r.Parent<Extension>().Value));
        descriptor.Field("valueAnnotation").Resolve(r => ValueResolvers.GetValue<Annotation>(r.Parent<Extension>().Value));
        descriptor.Field("valueAttachment").Resolve(r => ValueResolvers.GetValue<Attachment>(r.Parent<Extension>().Value));
        descriptor.Field("valueCodeableConcept").Resolve(r => ValueResolvers.GetValue<CodeableConcept>(r.Parent<Extension>().Value));
        descriptor.Field("valueCoding").Resolve(r => ValueResolvers.GetValue<Coding>(r.Parent<Extension>().Value));
        descriptor.Field("valueContactPoint").Resolve(r => ValueResolvers.GetValue<ContactPoint>(r.Parent<Extension>().Value));
        descriptor.Field("valueCount").Resolve(r => ValueResolvers.GetValue<Count>(r.Parent<Extension>().Value));
        descriptor.Field("valueDistance").Resolve(r => ValueResolvers.GetValue<Distance>(r.Parent<Extension>().Value));
        descriptor.Field("valueDuration").Resolve(r => ValueResolvers.GetValue<Duration>(r.Parent<Extension>().Value));
        descriptor.Field("valueHumanName").Resolve(r => ValueResolvers.GetValue<HumanName>(r.Parent<Extension>().Value));
        descriptor.Field("valueIdentifier").Resolve(r => ValueResolvers.GetValue<Identifier>(r.Parent<Extension>().Value));
        descriptor.Field("valueMoney").Resolve(r => ValueResolvers.GetValue<Money>(r.Parent<Extension>().Value));
        descriptor.Field("valuePeriod").Resolve(r => ValueResolvers.GetValue<Period>(r.Parent<Extension>().Value));
        descriptor.Field("valueQuantity").Resolve(r => ValueResolvers.GetValue<Quantity>(r.Parent<Extension>().Value));
        descriptor.Field("valueRange").Resolve(r => ValueResolvers.GetValue<Range>(r.Parent<Extension>().Value));
        descriptor.Field("valueRatio").Resolve(r => ValueResolvers.GetValue<Ratio>(r.Parent<Extension>().Value));
        descriptor.Field("valueSampledData").Resolve(r => ValueResolvers.GetValue<SampledData>(r.Parent<Extension>().Value));
        descriptor.Field("valueSignature").Resolve(r => ValueResolvers.GetValue<Signature>(r.Parent<Extension>().Value));
        descriptor.Field("valueTiming").Resolve(r => ValueResolvers.GetValue<Timing>(r.Parent<Extension>().Value));
        descriptor.Field("valueContactDetail").Resolve(r => ValueResolvers.GetValue<ContactDetail>(r.Parent<Extension>().Value));
        descriptor.Field("valueContributor").Resolve(r => ValueResolvers.GetValue<Contributor>(r.Parent<Extension>().Value));
        descriptor.Field("valueDataRequirement").Resolve(r => ValueResolvers.GetValue<DataRequirement>(r.Parent<Extension>().Value));
        descriptor.Field("valueExpression").Resolve(r => ValueResolvers.GetValue<Expression>(r.Parent<Extension>().Value));
        descriptor.Field("valueParameterDefinition").Resolve(r => ValueResolvers.GetValue<ParameterDefinition>(r.Parent<Extension>().Value));
        descriptor.Field("valueRelatedArtifact").Resolve(r => ValueResolvers.GetValue<RelatedArtifact>(r.Parent<Extension>().Value));
        descriptor.Field("valueTriggerDefinition").Resolve(r => ValueResolvers.GetValue<TriggerDefinition>(r.Parent<Extension>().Value));
        descriptor.Field("valueUsageContext").Resolve(r => ValueResolvers.GetValue<UsageContext>(r.Parent<Extension>().Value));
        descriptor.Field("valueDosage").Resolve(r => ValueResolvers.GetValue<Dosage>(r.Parent<Extension>().Value));
        descriptor.Field("valueMeta").Resolve(r => ValueResolvers.GetValue<Meta>(r.Parent<Extension>().Value));
    }
}
