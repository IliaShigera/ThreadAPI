namespace Thread.Modules.UserAccess.Domain.UserRegistration.Rules;

internal sealed class RegistrationEmailShouldBeUniqueDomainRule : IDomainRule
{
    private readonly string _email;
    private readonly IUniqUser _uniqUser;

    public RegistrationEmailShouldBeUniqueDomainRule(string email, IUniqUser uniqUser) =>
        (_email, _uniqUser) = (email, uniqUser);

    public string Details => $"Email: {_email} is already taken.";

    public bool IsBroken() => !_uniqUser.IsUniqEmail(_email);
}