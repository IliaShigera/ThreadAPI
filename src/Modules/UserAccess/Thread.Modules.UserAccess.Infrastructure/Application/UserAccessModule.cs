﻿namespace Thread.Modules.UserAccess.Infrastructure.Application;

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

    public async Task ConfirmRegistrationAsync(string confirmationToken, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new ConfirmRegistrationCommand(confirmationToken), cancellationToken);
    }

    public async Task<AuthResultDto> GetAuthTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetAuthTokenQuery(email, password), cancellationToken);
    }
}