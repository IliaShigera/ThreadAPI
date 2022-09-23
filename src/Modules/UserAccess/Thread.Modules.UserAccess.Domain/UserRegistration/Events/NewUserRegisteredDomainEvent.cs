namespace Thread.Modules.UserAccess.Domain.UserRegistration.Events;

public sealed class NewUserRegisteredDomainEvent : IDomainEvent
{
    public NewUserRegisteredDomainEvent(Guid registrationId)
    {
        RegistrationId = registrationId;
    }

    public Guid RegistrationId { get; }
}