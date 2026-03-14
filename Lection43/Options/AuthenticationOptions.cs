namespace Lection43.Options;

public class AuthenticationOptions
{
    public string SecretKeyFor { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audiance { get; set; } = string.Empty;
}
