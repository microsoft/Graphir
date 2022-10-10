using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;

using HotChocolate.Types;

namespace Graphir.API.Schema;

public class ScheduleType : ObjectType<Schedule>
{
    protected override void Configure(IObjectTypeDescriptor<Schedule> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Text).Type<NarrativeType>();
        descriptor.Field(x => x.Extension).Type<ListType<ExtensionType>>();
        descriptor.Field(x => x.Identifier).Type<ListType<IdentifierType>>();
        descriptor.Field(x => x.Active).Type<BooleanType>();
        descriptor.Field(x => x.ServiceCategory).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.ServiceType).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Specialty).Type<ListType<CodeableConceptType>>();
        // TODO: descriptor.Field(x => x.Actor).Type<ListType<ReferenceType>>(); //TODO: Resolver
        descriptor.Field(x => x.PlanningHorizon).Type<PeriodType>();
        descriptor.Field(x => x.Comment).Type<StringType>();
        
    }
}

#region QueryExtensions
public class ScheduleQuery : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field("Schedule")
            .Type<ScheduleType>()
            .Argument("id", a => a.Type<NonNullType<StringType>>())
            .ResolveWith<ResourceResolvers<Schedule>>(r => r.GetResource(default!, default!));

        descriptor.Field("ScheduleList")
            .Type<ListType<ScheduleType>>()
            .ResolveWith<ResourceResolvers<Schedule>>(r => r.GetResources(default!));
    }
}
#endregion