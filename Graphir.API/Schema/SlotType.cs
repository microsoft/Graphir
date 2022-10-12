using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class SlotType : ObjectType<Slot>
{
    protected override void Configure(IObjectTypeDescriptor<Slot> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Start).Type<DateTimeType>();
        descriptor.Field(x => x.End).Type<DateTimeType>();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.ServiceCategory).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.ServiceType).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Specialty).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.AppointmentType).Type<CodeableConceptType>();
        descriptor.Field(x => x.Comment).Type<StringType>();
        descriptor.Field(x => x.Overbooked).Type<BooleanType>();
        descriptor.Field(x => x.TypeName).Type<StringType>();
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
