namespace Thread.Modules.UserAccess.Infrastructure.Configuration;

internal sealed class SmtpConfiguration
{
    internal const string SECTION_NAME = "SmtpConfig";
    
    public string Host { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}