namespace Thread.Modules.UserAccess.Application.Contracts;

public interface IUserAccessDbContext
{
    DbSet<UserRegistration> Registrations { get; }

    Task CommitAsync(CancellationToken cancellationToken = default);
}