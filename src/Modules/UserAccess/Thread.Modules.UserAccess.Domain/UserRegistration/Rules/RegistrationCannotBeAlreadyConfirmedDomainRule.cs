namespace Thread.Modules.UserAccess.Domain.UserRegistration.Rules;

internal sealed class RegistrationCannotBeAlreadyConfirmedDomainRule : IDomainRule
{
    private readonly RegistrationStatus _status;

    public RegistrationCannotBeAlreadyConfirmedDomainRule(RegistrationStatus status) => _status = status;

    public string Details => "Registration is already confirmed.";

    public bool IsBroken() => _status.Equals(RegistrationStatus.Confirmed);
}