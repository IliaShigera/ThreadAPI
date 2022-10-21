namespace Thread.Modules.UserAccess.Infrastructure.Configuration;

internal sealed class LinkConfiguration
{
    public string ApiUri { get; } = HostEnvironment.Uri;
}