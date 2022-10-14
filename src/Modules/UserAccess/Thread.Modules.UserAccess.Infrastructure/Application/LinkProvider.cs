namespace Thread.Modules.UserAccess.Infrastructure.Application;

internal sealed class LinkProvider : ILinkProvider
{
    private readonly LinkConfiguration _configuration;

    public LinkProvider(LinkConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GetUserRegistrationConfirmationLink(string registrationConfirmToken)
    {
        var confirmUrl = $"{_configuration.ApiUri}/registrations/confirm/{registrationConfirmToken}";
        var link = $"<a href=\"{confirmUrl}\">link</a>";
        return link;
    }
}