namespace Thread.Modules.UserAccess.Application.Contracts;

public interface ITokenClaimsService
{
    string GenerateAuthToken(ApplicationUser user);
}