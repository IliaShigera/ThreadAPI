namespace Thread.Modules.UserAccess.Application.Contracts;

public interface IEmailSender
{
    Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default);
}