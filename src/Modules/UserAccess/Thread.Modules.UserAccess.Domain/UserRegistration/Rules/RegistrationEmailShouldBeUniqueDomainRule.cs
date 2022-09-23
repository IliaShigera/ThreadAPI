namespace Thread.Modules.UserAccess.Domain.UserRegistration.Rules;

internal sealed class RegistrationEmailShouldBeUniqueDomainRule : IDomainRule
{
    private readonly string _email;
    private readonly IUniqueUser _uniqueUser;

    public RegistrationEmailShouldBeUniqueDomainRule(string email, IUniqueUser uniqueUser) =>
        (_email, _uniqueUser) = (email, uniqueUser);

    public string Details => $"Email: {_email} is already taken.";

    public bool IsBroken() => !_uniqueUser.IsUniqEmail(_email);
}