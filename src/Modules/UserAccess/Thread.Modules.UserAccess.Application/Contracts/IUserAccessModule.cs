namespace Thread.Modules.UserAccess.Application.Contracts;

public interface IUserAccessModule
{
    Task RegisterNewUserAsync(string email, string password, CancellationToken cancellationToken = default);
    Task ConfirmRegistrationAsync(Guid registrationId, CancellationToken cancellationToken = default);
    Task<AuthResultDto> GetAuthTokenAsync(string email, string password, CancellationToken cancellationToken = default);
}