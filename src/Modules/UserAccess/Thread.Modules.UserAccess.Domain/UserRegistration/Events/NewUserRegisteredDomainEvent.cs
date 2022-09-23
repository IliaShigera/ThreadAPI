namespace Thread.Modules.UserAccess.Domain.UserRegistration.Events;

public sealed class NewUserRegisteredDomainEvent : IDomainEvent
{
    public NewUserRegisteredDomainEvent(Guid registrationId, string userEmail)
    {
        RegistrationId = registrationId;
        UserEmail = userEmail;
    }

    public Guid RegistrationId { get; }
    public string UserEmail { get; }
}