namespace Thread.Modules.UserAccess.Domain.UserRegistration;

public interface IUniqUser
{
    bool IsUniqEmail(string email);
}