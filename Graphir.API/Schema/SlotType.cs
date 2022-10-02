using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Graphir.API.Slots;

using Hl7.Fhir.Model;

using HotChocolate;
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
        descriptor.Field(x => x.Schedule).ResolveWith<SlotResolver>
            (c => SlotResolver.GetSchedule(default!, default!, default));
    }

    protected sealed class SlotResolver
    {
        public static async Task<Schedule> GetSchedule([Parent] Slot slot,
            SlotDataLoaders loadScheduleById, CancellationToken cancellationToken)
        {
            var scheduleReference = slot.Schedule.Reference.Split('/').LastOrDefault();
            return await loadScheduleById.LoadAsync(scheduleReference!, cancellationToken);
        }
    }
}