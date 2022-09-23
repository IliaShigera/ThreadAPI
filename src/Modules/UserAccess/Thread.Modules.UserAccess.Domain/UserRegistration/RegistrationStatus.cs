namespace Thread.Modules.UserAccess.Domain.UserRegistration;

public sealed class RegistrationStatus : ValueObject
{
    private RegistrationStatus() { }

    private RegistrationStatus(string value) => Value = value;

    public string Value { get; init; }

    public static RegistrationStatus WaitToConfirm => new(nameof(WaitToConfirm));
    public static RegistrationStatus Confirmed => new(nameof(Confirmed));
    public static RegistrationStatus Expired => new(nameof(Expired));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    } 
}