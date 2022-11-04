using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class ComponentType : InterfaceType<BackboneElement>
    {
        protected override void Configure(IInterfaceTypeDescriptor<BackboneElement> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.ElementId);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.ModifierExtension);
        }
    }

}
