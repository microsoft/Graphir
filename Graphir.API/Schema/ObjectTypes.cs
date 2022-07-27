namespace Graphir.API.Schema
{
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

    public class CodeableConceptType : ObjectType<CodeableConcept>
    {
        protected override void Configure(IObjectTypeDescriptor<CodeableConcept> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Coding);
            descriptor.Field(c => c.Text);
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

    public class ResourceReferenceType : ObjectType<ResourceReference>
    {
        protected override void Configure(IObjectTypeDescriptor<ResourceReference> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(r => r.Identifier);
            descriptor.Field(r => r.Reference);
            descriptor.Field(r => r.Display);
            descriptor.Field(r => r.Type);
        }
    }

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
}