namespace Graphir.API.Schema;

public class PatientUpdate : IResourceUpdate<Patient>
{
    public Patient Resource { get; set; }
    public OperationOutcome Information { get; set; }
}