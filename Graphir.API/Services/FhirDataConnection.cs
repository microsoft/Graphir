namespace Graphir.API.Services;

public class FhirDataConnection
{
    public string BaseUrl { get; set; }
    public string Scopes { get; set; }
    /// <summary>
    /// Enables on-behalf of flow with downstream token acquisition for Azure AD
    /// </summary>
    public bool UseAuthentication { get; set; }
}