namespace Graphir.API.Schema;

[InterfaceType("ResourceCreation")]
public interface IResourceCreation<T> where T : Resource
{
    public string Location { get; set; }
    public T Resource { get; set; }
    public OperationOutcome Information { get; set; }
}