namespace Thread.Modules.UserAccess.Application.Exceptions;

public sealed class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string details)
    {
        Details = details;
    }

    public string Details { get; } 
}