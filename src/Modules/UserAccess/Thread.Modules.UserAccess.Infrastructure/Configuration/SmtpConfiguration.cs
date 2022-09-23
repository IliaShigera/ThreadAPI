namespace Thread.Modules.UserAccess.Infrastructure.Configuration;

internal sealed class SmtpConfiguration
{
    internal const string SECTION_NAME = "SmtpConfig";
    
    internal string Host { get; set; }
    internal int Port { get; set; }
    internal string UserName { get; set; }
    internal string Email { get; set; }
    internal string Password { get; set; }
}