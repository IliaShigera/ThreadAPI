namespace Thread.Modules.UserAccess.Application.Contracts;

public interface ILinkProvider
{
    string GetUserRegistrationConfirmationLink(string registrationConfirmToken);
}