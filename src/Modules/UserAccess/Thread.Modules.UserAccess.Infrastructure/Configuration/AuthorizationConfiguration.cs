namespace Thread.Modules.UserAccess.Infrastructure.Configuration;

internal sealed class AuthorizationConfiguration
{
    internal const string SECTION_NAME = "AuthConfig";

    public string JwtSecretKey { get; set; }
    public int ExpiresDays { get; set; }
}