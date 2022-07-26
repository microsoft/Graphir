namespace Graphir.API.Schema;

[InterfaceType("ResourceDelete")]
public interface IResourceDelete<T> where T : Resource
{
    public OperationOutcome Information { get; set; }
}