namespace Graphir.API.Schema;

public class PatientCreation : IResourceCreation<Patient>
{
    public string Location { get; set; }
    public Patient Resource { get; set; }
    public OperationOutcome Information { get; set; }
}