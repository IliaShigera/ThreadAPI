namespace Thread.Modules.UserAccess.Domain.UserRegistration.Events;

public sealed class RegistrationConfirmedDomainEvent : IDomainEvent
{
    public RegistrationConfirmedDomainEvent(Guid registrationId)
    {
        RegistrationId = registrationId;
    }

    public Guid RegistrationId { get; }
}