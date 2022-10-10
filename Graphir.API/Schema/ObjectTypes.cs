using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

public class ExtensionType : ObjectType<Extension>
{
    protected override void Configure(IObjectTypeDescriptor<Extension> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Url);
        descriptor.Field(x => x.Value).Type<StringType>();
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
        descriptor.Field(x => x.Value).Type<NonNullType<StringType>>();
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
        descriptor.Field(x => x.Numerator).Type<QuantityType>();
        descriptor.Field(x => x.Denominator).Type<QuantityType>();
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