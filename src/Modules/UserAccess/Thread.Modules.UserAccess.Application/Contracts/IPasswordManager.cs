namespace Thread.Modules.UserAccess.Application.Contracts;

public interface IPasswordManager
{
    string HashPassword(string password);
    
    bool VerifyHashedPassword(string hashedPassword, string password);
}