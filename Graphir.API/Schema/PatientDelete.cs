namespace Graphir.API.Schema;

public class PatientDelete : IResourceDelete<Patient>
{
    public OperationOutcome Information { get; set; }
}