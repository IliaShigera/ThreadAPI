namespace Thread.Modules.UserAccess.Application.Features.Registration;

public sealed record ConfirmRegistrationCommand(string ConfirmationToken) : ICommand;

internal sealed class ConfirmRegistrationCommandHandler : ICommandHandler<ConfirmRegistrationCommand>
{
    private readonly IUserAccessDbContext _dbContext;

    public ConfirmRegistrationCommandHandler(IUserAccessDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(ConfirmRegistrationCommand command, CancellationToken cancellationToken)
    {
        var registration = await _dbContext.Registrations
            .FirstOrDefaultAsync(x => x.ConfirmationToken.Equals(command.ConfirmationToken), cancellationToken);

        if (registration is null)
            throw new SpecNotFoundException($"Registration token: {command.ConfirmationToken} is invalid.", nameof(Registration));

        registration.Confirm();

        _dbContext.Registrations.Update(registration);
        await _dbContext.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}