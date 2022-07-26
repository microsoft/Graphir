namespace Graphir.API.Schema;

[InterfaceType("ResourceUpdate")]
public interface IResourceUpdate<T> where T : Resource
{
    public T Resource { get; set; }
    public OperationOutcome Information { get; set; }
}