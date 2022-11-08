using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class SlotType : ObjectType<Slot>
{
    protected override void Configure(IObjectTypeDescriptor<Slot> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Start);
        descriptor.Field(x => x.End);
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.ServiceCategory);
        descriptor.Field(x => x.ServiceType);
        descriptor.Field(x => x.Specialty);
        descriptor.Field(x => x.AppointmentType);
        descriptor.Field(x => x.Comment);
        descriptor.Field(x => x.Overbooked);
        descriptor.Field(x => x.TypeName);
        descriptor.Field(x => x.Schedule).Type<ResourceReferenceType<SlotScheduleReferenceType>>();
    }
}

public class SlotScheduleReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("SlotScheduleReference");
        descriptor.Type<ScheduleType>();
    }
}