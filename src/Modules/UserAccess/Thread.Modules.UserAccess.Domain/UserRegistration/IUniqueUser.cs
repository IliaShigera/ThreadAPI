namespace Thread.Modules.UserAccess.Domain.UserRegistration;

public interface IUniqueUser
{
    bool IsUniqEmail(string email);
}