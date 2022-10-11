using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class EncounterType : ObjectType<Encounter>
    {
        // TODO: finish Encounter
        protected override void Configure(IObjectTypeDescriptor<Encounter> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(e => e.Id);
        }
    }


    #region QueryExtensions
    public class EncounterQuery : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field("Encounter")
                .Type<EncounterType>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<Encounter>>(r => r.GetResource(default!, default!));

            descriptor.Field("EncounterList")
                .Type<ListType<EncounterType>>()
                .ResolveWith<ResourceResolvers<Encounter>>(r => r.GetResources(default!));
        }
    }
    #endregion
}
