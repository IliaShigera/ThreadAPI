using Thread.Modules.UserAccess.Application.Exceptions;

namespace Thread.Modules.UserAccess.Application.Registration;

internal sealed class ConfirmRegistrationCommand : ICommand
{
    public ConfirmRegistrationCommand(Guid registrationId)
    {
        RegistrationId = registrationId;
    }

    public Guid RegistrationId { get; }
}

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
            .FirstOrDefaultAsync(x => x.Id == command.RegistrationId, cancellationToken);

        if (registration is null)
            throw new SpecNotFoundException($"Registration with id: {command.RegistrationId} not exists.", nameof(Registration));

        registration.Confirm();

        _dbContext.Registrations.Update(registration);
        await _dbContext.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}