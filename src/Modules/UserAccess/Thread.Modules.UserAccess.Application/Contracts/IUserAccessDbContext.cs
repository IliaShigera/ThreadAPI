namespace Thread.Modules.UserAccess.Application.Contracts;

public interface IUserAccessDbContext : IDbContext
{
    DbSet<UserRegistration> Registrations { get; }
}