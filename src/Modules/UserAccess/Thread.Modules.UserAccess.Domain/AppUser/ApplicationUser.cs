namespace Thread.Modules.UserAccess.Domain.AppUser;

public sealed class ApplicationUser : Entity, IAggregateRoot
{
    private ApplicationUser() { }

    internal ApplicationUser(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }

    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
}