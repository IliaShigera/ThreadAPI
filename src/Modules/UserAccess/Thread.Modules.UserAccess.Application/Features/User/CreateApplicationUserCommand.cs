namespace Thread.Modules.UserAccess.Application.Features.User;

internal sealed class CreateApplicationUserCommand : IDomainEventHandler<RegistrationConfirmedDomainEvent>
{
    private readonly IUserAccessDbContext _dbContext;

    public CreateApplicationUserCommand(IUserAccessDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(RegistrationConfirmedDomainEvent @event, CancellationToken cancellationToken)
    {
        var registration = await _dbContext.Registrations
            .FirstOrDefaultAsync(r => r.Id.Equals(@event.RegistrationId), cancellationToken);

        if (registration is null)
            throw new SpecNotFoundException($"Registration with id: {@event.RegistrationId} not exists.", nameof(Registration));

        var appUser = registration.CreateAppUserFromRegistration();
        await _dbContext.Users.AddAsync(appUser, cancellationToken);
        await _dbContext.CommitAsync(cancellationToken);
    }
}