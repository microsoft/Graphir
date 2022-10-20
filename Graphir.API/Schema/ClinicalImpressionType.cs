using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ClinicalImpressionType : ObjectType<ClinicalImpression>
{
    /*TODO: Need to add support for the following properties:
    type ClinicalImpression {
        id: ID
        meta: Meta
        implicitRules: uri  _implicitRules: ElementBase
        language: code  _language: ElementBase
        text: Narrative
        contained: [Resource]
        extension: [Extension]
        modifierExtension: [Extension]
        identifier: [Identifier]
        status: code  _status: ElementBase
        statusReason: CodeableConcept
        description: String  _description: ElementBase
        subject: Reference!
        encounter: Reference
        effectiveDateTime: dateTime  _effectiveDateTime: ElementBase
        effectivePeriod: Period
        date: dateTime  _date: ElementBase
        performer: Reference
        previous: Reference
        problem: [Reference]
        protocol: uri  _protocol: [ElementBase]
        summary: String  _summary: ElementBase
        finding: [ClinicalImpressionFinding]
        prognosisCodeableConcept: [CodeableConcept]
        prognosisReference: [Reference]
        supportingInfo: [Reference]
        note: [Annotation]
    }*/
    
    protected override void Configure(IObjectTypeDescriptor<ClinicalImpression> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Id);
    }
}
