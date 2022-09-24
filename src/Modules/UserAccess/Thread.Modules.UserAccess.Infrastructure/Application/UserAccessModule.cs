namespace Thread.Modules.UserAccess.Infrastructure.Application;

internal sealed class UserAccessModule : IUserAccessModule
{
    private readonly IMediator _mediator;

    public UserAccessModule(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task RegisterNewUserAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new RegisterUserCommand(email, password), cancellationToken);
    }

    public async Task ConfirmRegistrationAsync(Guid registrationId, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new ConfirmRegistrationCommand(registrationId), cancellationToken);
    }
}