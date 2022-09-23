namespace Thread.Modules.UserAccess.Domain.UserRegistration.Rules;

internal sealed class RegistrationCannotBeAlreadyExpiredDomainRule : IDomainRule
{
    private readonly RegistrationStatus _status;
    
    public RegistrationCannotBeAlreadyExpiredDomainRule(RegistrationStatus status) => _status = status;

    public string Details => "Registration is already expired.";

    public bool IsBroken() => _status.Equals(RegistrationStatus.Expired);
}