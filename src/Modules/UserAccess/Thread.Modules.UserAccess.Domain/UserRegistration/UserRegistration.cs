namespace Thread.Modules.UserAccess.Domain.UserRegistration;

public sealed class UserRegistration : Entity, IAggregateRoot
{
    private UserRegistration() { }

    private UserRegistration(string email, string passwordHash, IUniqueUser uniqueUser)
    {
        CheckRule(new RegistrationEmailShouldBeUniqueDomainRule(email, uniqueUser));

        Email = email;
        PasswordHash = passwordHash;
        RegisteredOn = DateTime.UtcNow;
        Status = RegistrationStatus.WaitToConfirm;
    }

    public string Email { get; init; }
    public string PasswordHash { get; init; }
    public DateTime RegisteredOn { get; init; }
    public RegistrationStatus Status { get; private set; }

    public static UserRegistration RegisterNewUser(string email, string passwordHash, IUniqueUser uniqueUser) =>
        new(email, passwordHash, uniqueUser);

    public void Confirm()
    {
        CheckRule(new RegistrationCannotBeAlreadyConfirmedDomainRule(Status));
        CheckRule(new RegistrationCannotBeAlreadyExpiredDomainRule(Status));

        Status = RegistrationStatus.Confirmed;

        AddDomainEvent(new RegistrationConfirmedDomainEvent(Id));
    }

    public void Expired()
    {
        CheckRule(new RegistrationCannotBeAlreadyExpiredDomainRule(Status));
        CheckRule(new RegistrationCannotBeAlreadyConfirmedDomainRule(Status));

        Status = RegistrationStatus.Expired;

        AddDomainEvent(new RegistrationExpiredDomainEvent(Id));
    }
}