using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class GroupType : ObjectType<Group>
{
    protected override void Configure(IObjectTypeDescriptor<Group> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(g => g.Id);
        //descriptor.Field(g => g.Meta);
        //descriptor.Field(g => g.Language);
        //descriptor.Field(g => g.Text);
        //descriptor.Field(g => g.Identifier);
        //descriptor.Field(g => g.Active);
        //descriptor.Field(g => g.Type);
        //descriptor.Field(g => g.Actual);
        //descriptor.Field(g => g.Code);
        //descriptor.Field(g => g.Name);
        //descriptor.Field(g => g.Quantity);
        //descriptor.Field(g => g.ManagingEntity);
        //descriptor.Field(g => g.Characteristic);
        //descriptor.Field(g => g.Member);
    }
}

public class GroupCharacteristic : ObjectType<Group.CharacteristicComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Group.CharacteristicComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(g => g.Code);
        descriptor.Field(g => g.Exclude);
        descriptor.Field(g => g.Period);

        descriptor.Field("valueCodeableConcept")
            .Resolve(context =>
            {
                var parent = context.Parent<Group.CharacteristicComponent>();
                return (parent.Value is not null && parent.Value.TypeName == "CodeableConcept")
                    ? (CodeableConcept)parent.Value
                    : null;
            });
        descriptor.Field("valueBoolean")
            .Resolve(context =>
            {
                var parent = context.Parent<Group.CharacteristicComponent>();
                return (parent.Value is not null && parent.Value.TypeName == "boolean")
                    ? (FhirBoolean)parent.Value
                    : null;
            });
        descriptor.Field("valueQuantity")
            .Resolve(context =>
            {
                var parent = context.Parent<Group.CharacteristicComponent>();
                return (parent.Value is not null && parent.Value.TypeName == "Quantity")
                    ? (Quantity)parent.Value
                    : null;
            });
        descriptor.Field("valueRange")
            .Resolve(context =>
            {
                var parent = context.Parent<Group.CharacteristicComponent>();
                return (parent.Value is not null && parent.Value.TypeName == "Range")
                    ? (Range)parent.Value
                    : null;
            });
        descriptor.Field("valueReference").Type<ResourceReferenceType<GroupCharacteristicValueReferenceType>>()
            .Resolve(context =>
            {
                var parent = context.Parent<Group.CharacteristicComponent>();
                return (parent.Value is not null && parent.Value.TypeName == "Reference")
                    ? (ResourceReference)parent.Value
                    : null;
            });
    }
}

public class GroupMember : ObjectType<Group.MemberComponent>
{
    protected override void Configure(IObjectTypeDescriptor<Group.MemberComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(g => g.Entity).Type<ResourceReferenceType<GroupMemberReferenceType>>();
        descriptor.Field(g => g.Period);
        descriptor.Field(g => g.Inactive);
    }
}

public class GroupMemberReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("GroupMemberReference");
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<MedicationType>();
        //descriptor.Type<SubstanceType>();
        descriptor.Type<GroupType>();
        /* TODO: implement missing reference types */
    }
}

public class GroupCharacteristicValueReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("GroupCharacteristicValueReference");
        descriptor.Type<ResourceType>();
    }
}
