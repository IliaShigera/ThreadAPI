namespace Thread.Modules.UserAccess.Domain.UserRegistration.Events;

public sealed class NewUserRegisteredDomainEvent : IDomainEvent
{
    public NewUserRegisteredDomainEvent(string userEmail, string confirmationToken)
    {
        UserEmail = userEmail;
        ConfirmationToken = confirmationToken;
    }

    public string UserEmail { get; }
    public string ConfirmationToken { get; }
}