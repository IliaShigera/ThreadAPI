namespace Thread.Modules.UserAccess.Application.Features.Auth;

public sealed class AuthResultDto
{
    public AuthResultDto(string token)
    {
        Token = token;
    }

    public string Token { get; }
}