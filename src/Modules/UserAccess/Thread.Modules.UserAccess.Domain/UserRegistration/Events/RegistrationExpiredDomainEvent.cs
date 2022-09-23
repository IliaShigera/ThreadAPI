namespace Thread.Modules.UserAccess.Domain.UserRegistration.Events;

public sealed class RegistrationExpiredDomainEvent : IDomainEvent
{
    public RegistrationExpiredDomainEvent(Guid registrationId)
    {
        RegistrationId = registrationId;
    }

    public Guid RegistrationId { get; }
}