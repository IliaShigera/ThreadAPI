namespace Thread.Modules.UserAccess.Domain.UserRegistration.Rules;

internal sealed class RegistrationShouldBeConfirmed : IDomainRule
{
    private readonly RegistrationStatus _status;

    public RegistrationShouldBeConfirmed(RegistrationStatus status) => _status = status;

    public string Details => "User cannot be created, registration is not confirmed.";

    public bool IsBroken() => !_status.Equals(RegistrationStatus.Confirmed);
}