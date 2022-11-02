using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ResourceType : ObjectType<Resource>
{
    protected override void Configure(IObjectTypeDescriptor<Resource> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(r => r.Id);
    }
}

public class ResourceReferenceType<T> : ObjectType<ResourceReference> where T : UnionType
{
    protected override void Configure(IObjectTypeDescriptor<ResourceReference> descriptor)
    {
        descriptor.Name(dep => dep.Name + "Resolver").DependsOn<T>();

        descriptor.BindFieldsExplicitly();

        descriptor.Field(r => r.Identifier);        
        descriptor.Field(r => r.Display);
        descriptor.Field(r => r.Type);
        descriptor.Field(r => r.Reference);
        descriptor.Field("resource").Type<T>()
            .ResolveWith<ResourceReferenceResolvers>(r => r.GetResourceAsync(default!, default!, default));
    }

}

public class IdentifierType : ObjectType<Identifier>
{
    protected override void Configure(IObjectTypeDescriptor<Identifier> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(i => i.Use);
        descriptor.Field(i => i.Type);
        descriptor.Field(i => i.System);
        descriptor.Field(i => i.Value);
    }
}

public class MetaType : ObjectType<Meta>
{
    protected override void Configure(IObjectTypeDescriptor<Meta> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(m => m.VersionId);
        descriptor.Field(m => m.LastUpdated);
        descriptor.Field(m => m.Source);
        descriptor.Field(m => m.Profile);
        descriptor.Field(m => m.Security);
        descriptor.Field(m => m.Tag);
    }
}

public class FhirStringType : ObjectType<FhirString>
{
    protected override void Configure(IObjectTypeDescriptor<FhirString> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Value);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.TypeName);
    }
}

public class CodeableConceptType : ObjectType<CodeableConcept>
{
    protected override void Configure(IObjectTypeDescriptor<CodeableConcept> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Coding);
        descriptor.Field(c => c.Text);
    }
}

public class CodeableReferenceType<T> : ObjectType<CodeableReference> where T : UnionType
{
    protected override void Configure(IObjectTypeDescriptor<CodeableReference> descriptor)
    {
        descriptor.Name(d => d.Name + "CodeableReference").DependsOn<T>();
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Concept).Type<CodeableConceptType>();
        descriptor.Field(c => c.Reference).Type<ResourceReferenceType<T>>();
    }
}

public class CodingType : ObjectType<Coding>
{
    protected override void Configure(IObjectTypeDescriptor<Coding> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.Code);
        descriptor.Field(c => c.Display);
        descriptor.Field(c => c.System);
        descriptor.Field(c => c.TypeName);
        descriptor.Field(c => c.UserSelected);
        descriptor.Field(c => c.Version);
    }
}

public class HumanNameType : ObjectType<HumanName>
{
    protected override void Configure(IObjectTypeDescriptor<HumanName> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(h => h.Family);
        descriptor.Field(h => h.Given);
        descriptor.Field(h => h.Period);
        descriptor.Field(h => h.Prefix);
        descriptor.Field(h => h.Suffix);
        descriptor.Field(h => h.Text);
    }
}

public class PeriodType : ObjectType<Period>
{
    protected override void Configure(IObjectTypeDescriptor<Period> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(p => p.End);
        descriptor.Field(p => p.Start);
    }
}

public class ContactPointType : ObjectType<ContactPoint>
{
    protected override void Configure(IObjectTypeDescriptor<ContactPoint> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(c => c.System);
        descriptor.Field(c => c.Value);
        descriptor.Field(c => c.Use);
        descriptor.Field(c => c.Rank);
        descriptor.Field(c => c.Period);
    }
}

public class AddressType : ObjectType<Address>
{
    protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(a => a.Use);
        descriptor.Field(a => a.Type);
        descriptor.Field(a => a.Text);
        descriptor.Field(a => a.Line);
        descriptor.Field(a => a.City);
        descriptor.Field(a => a.District);
        descriptor.Field(a => a.State);
        descriptor.Field(a => a.PostalCode);
        descriptor.Field(a => a.Country);
        descriptor.Field(a => a.Period);
    }
}

public class AttachmentType : ObjectType<Attachment>
{
    protected override void Configure(IObjectTypeDescriptor<Attachment> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(a => a.ContentType);
        descriptor.Field(a => a.Language);
        descriptor.Field(a => a.Data);
        descriptor.Field(a => a.Url);
        descriptor.Field(a => a.Size);
        descriptor.Field(a => a.Hash);
        descriptor.Field(a => a.Title);
        descriptor.Field(a => a.Creation);
    }
}

public class OperationOutcomeType : ObjectType<OperationOutcome>
{
    protected override void Configure(IObjectTypeDescriptor<OperationOutcome> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(o => o.Errors);
        descriptor.Field(o => o.Fatals);
        descriptor.Field(o => o.HasVersionId);
        descriptor.Field(o => o.Issue);
        descriptor.Field(o => o.Language);
        descriptor.Field(o => o.Warnings);
        descriptor.Field(o => o.Success);
    }
}

public class OperationOutcomeIssueComponentType : ObjectType<OperationOutcome.IssueComponent>
{
    protected override void Configure(IObjectTypeDescriptor<OperationOutcome.IssueComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(i => i.Code.ToString())
            .Name("code");
        descriptor.Field(i => i.Details);
        descriptor.Field(i => i.Diagnostics);
        descriptor.Field(i => i.HierarchyLevel);
        descriptor.Field(i => i.Location);
        descriptor.Field(i => i.Severity.ToString())
            .Name("severity");
        descriptor.Field(i => i.Success);
    }
}

public class AnnotationType : ObjectType<Annotation>
{
    protected override void Configure(IObjectTypeDescriptor<Annotation> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        //descriptor.Field(x => x.Author).Type<PractitionerType>(); //TODO: resolver
        descriptor.Field(x => x.Time);
        descriptor.Field(x => x.Text).Type<MarkDownType>();

    }
}

public class QuantityType : ObjectType<Quantity>
{
    protected override void Configure(IObjectTypeDescriptor<Quantity> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Value);
        descriptor.Field(x => x.Comparator);
        descriptor.Field(x => x.Unit);
        descriptor.Field(x => x.System);
        descriptor.Field(x => x.Code);
    }
}

public class MoneyType : ObjectType<Money>
{
    protected override void Configure(IObjectTypeDescriptor<Money> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(m => m.Currency);
        descriptor.Field(m => m.Value);
    }
}

public class NarrativeType : ObjectType<Narrative>
{
    protected override void Configure(IObjectTypeDescriptor<Narrative> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Div);
    }
}

public class RatioType : ObjectType<Ratio>
{
    protected override void Configure(IObjectTypeDescriptor<Ratio> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Numerator);
        descriptor.Field(x => x.Denominator);
    }
}

public class DosageType : ObjectType<Dosage>
{
    protected override void Configure(IObjectTypeDescriptor<Dosage> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Sequence);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.AdditionalInstruction);
        descriptor.Field(x => x.PatientInstruction);
        descriptor.Field(x => x.Timing);
        descriptor.Field(x => x.Site);
        descriptor.Field(x => x.Route);
        descriptor.Field(x => x.Method);
        descriptor.Field(x => x.DoseAndRate);
        descriptor.Field(x => x.MaxDosePerPeriod);
        descriptor.Field(x => x.MaxDosePerAdministration);
        descriptor.Field(x => x.MaxDosePerLifetime);
        descriptor.Field("asNeededBoolean").Type<BooleanType>().Resolve(r =>
        {
            var parent = r.Parent<Dosage>();
            return parent.AsNeeded is not null && parent.AsNeeded.TypeName == "boolean"
            ? (FhirBoolean)parent.AsNeeded
            : null;
        });
        descriptor.Field("asNeededCodeableConcept").Type<CodeableConceptType>().Resolve(r =>
        {
            var parent = r.Parent<Dosage>();
            return parent.AsNeeded is not null && parent.AsNeeded.TypeName == "CodeableConcept"
            ? (CodeableConcept)parent.AsNeeded
            : null;
        });
    }
}

public class DoseAndRateType : ObjectType<Dosage.DoseAndRateComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Dosage.DoseAndRateComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Type);
        descriptor.Field("doseRange").Type<RangeType>().Resolve(r =>
        {
            var parent = r.Parent<Dosage.DoseAndRateComponent>();
            return parent.Dose is not null && parent.Dose.TypeName == "Range"
            ? (Range)parent.Dose
            : null;
        });
        descriptor.Field("doseQuantity").Type<QuantityType>().Resolve(r =>
        {
            var parent = r.Parent<Dosage.DoseAndRateComponent>();
            return parent.Dose is not null && parent.Dose.TypeName == "SimpleQuantity"
            ? (Quantity)parent.Dose
            : null;
        });
        descriptor.Field("rateRatio").Type<RatioType>().Resolve(r =>
        {
            var parent = r.Parent<Dosage.DoseAndRateComponent>();
            return parent.Rate is not null && parent.Dose.TypeName == "Ratio"
            ? (Ratio)parent.Rate
            : null;
        });
        descriptor.Field("rateRange").Type<RangeType>().Resolve(r =>
        {
            var parent = r.Parent<Dosage.DoseAndRateComponent>();
            return parent.Rate is not null && parent.Dose.TypeName == "Range"
            ? (Range)parent.Rate
            : null;
        });
        descriptor.Field("rateQuantity").Type<QuantityType>().Resolve(r =>
        {
            var parent = r.Parent<Dosage.DoseAndRateComponent>();
            return parent.Rate is not null && parent.Dose.TypeName == "SimpleQuantity"
            ? (Quantity)parent.Rate
            : null;
        });

    }
}

public class RangeType : ObjectType<Range>
{
    protected override void Configure(IObjectTypeDescriptor<Range> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Low);
        descriptor.Field(x => x.High);
    }
}

public class TimingType : ObjectType<Timing>
{
    protected override void Configure(IObjectTypeDescriptor<Timing> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Event).Type<ListType<DateTimeType>>(); // possible bug, leave type extension declaration
        descriptor.Field(x => x.Repeat);
        descriptor.Field(x => x.Code);
    }
}

public class TimingRepeatType : ObjectType<Timing.RepeatComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Timing.RepeatComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Count);
        descriptor.Field(x => x.CountMax);
        descriptor.Field(x => x.Duration);
        descriptor.Field(x => x.DurationMax);
        descriptor.Field(x => x.DurationUnit);
        descriptor.Field(x => x.Frequency);
        descriptor.Field(x => x.FrequencyMax);
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.PeriodMax);
        descriptor.Field(x => x.PeriodUnit);
        descriptor.Field(x => x.DayOfWeek);
        descriptor.Field(x => x.TimeOfDay);
        descriptor.Field(x => x.When);
        descriptor.Field(x => x.Offset);

        descriptor.Field("boundsDuration").Type<DurationType>().Resolve(r =>
        {
            var parent = r.Parent<Timing.RepeatComponent>();
            return parent.Bounds is not null && parent.Bounds.TypeName == "Duration"
            ? (Duration)parent.Bounds
            : null;
        });
        descriptor.Field("boundsRange").Type<RangeType>().Resolve(r =>
        {
            var parent = r.Parent<Timing.RepeatComponent>();
            return parent.Bounds is not null && parent.Bounds.TypeName == "Range"
            ? (Range)parent.Bounds
            : null;
        });
        descriptor.Field("boundsPeriod").Type<RangeType>().Resolve(r =>
        {
            var parent = r.Parent<Timing.RepeatComponent>();
            return parent.Bounds is not null && parent.Bounds.TypeName == "Period"
            ? (Period)parent.Bounds
            : null;
        });
    }
}

public class DurationType : ObjectType<Duration>
{
    protected override void Configure(IObjectTypeDescriptor<Duration> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Value);
        descriptor.Field(x => x.Comparator);
        descriptor.Field(x => x.Unit);
        descriptor.Field(x => x.System);
        descriptor.Field(x => x.Code);
    }
}

public class MarkDownType : ObjectType<Markdown>
{
    protected override void Configure(IObjectTypeDescriptor<Markdown> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Value);
        descriptor.Field(x => x.Extension);
    }
}

public class AgeType : ObjectType<Age>
{
    protected override void Configure(IObjectTypeDescriptor<Age> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Value);
        descriptor.Field(x => x.Comparator);
        descriptor.Field(x => x.Unit);
        descriptor.Field(x => x.System);
        descriptor.Field(x => x.Code);
    }
}

public class SampledDataType : ObjectType<SampledData>
{
    protected override void Configure(IObjectTypeDescriptor<SampledData> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Origin);
        descriptor.Field(x => x.Period);
        descriptor.Field(x => x.Factor);
        descriptor.Field(x => x.LowerLimit);
        descriptor.Field(x => x.UpperLimit);
        descriptor.Field(x => x.Dimensions);
        descriptor.Field(x => x.Data);
    }
}

public class DeviceReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Description("Reference(Device | DeviceMetric)");
        descriptor.Type<DeviceType>();
        descriptor.Type<DeviceMetricType>();
    }
}

public class FhirUriType : ObjectType<FhirUri>
{
    protected override void Configure(IObjectTypeDescriptor<FhirUri> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(p => p.Value);
        descriptor.Field(p => p.Extension);
    }
}

public class FhirUrlType : ObjectType<FhirUrl>
{
    protected override void Configure(IObjectTypeDescriptor<FhirUrl> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.Value);
    }
}


#region Interfaces

[InterfaceType("ResourceCreation")]
public interface IResourceCreation<T> where T : Resource
{
    public string Location { get; set; }
    public T Resource { get; set; }
    public OperationOutcome Information { get; set; }
}

[InterfaceType("ResourceUpdate")]
public interface IResourceUpdate<T> where T : Resource
{
    public T Resource { get; set; }
    public OperationOutcome Information { get; set; }
}

[InterfaceType("ResourceDelete")]
public interface IResourceDelete<T> where T : Resource
{
    public OperationOutcome Information { get; set; }
}

#endregion