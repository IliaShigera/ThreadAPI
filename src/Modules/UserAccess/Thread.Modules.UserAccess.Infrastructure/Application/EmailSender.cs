namespace Thread.Modules.UserAccess.Infrastructure.Application;

internal sealed class EmailSender : IEmailSender
{
    private readonly SmtpConfiguration _smtpConfig;

    public EmailSender(SmtpConfiguration smtpConfig)
    {
        _smtpConfig = smtpConfig;
    }
    
    public async Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default)
    {
        MimeMessage mailMessage = new();
        mailMessage.From.Add(new MailboxAddress(_smtpConfig.UserName, _smtpConfig.Email));
        mailMessage.To.Add(new MailboxAddress(default, message.To));
        mailMessage.Subject = message.Subject;
        mailMessage.Body = new TextPart(TextFormat.Html)
        {
            Text = message.Content
        };

        using SmtpClient smtpClient = new();
        await smtpClient.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port, true, cancellationToken);
        await smtpClient.AuthenticateAsync(_smtpConfig.UserName, _smtpConfig.Password, cancellationToken);
        await smtpClient.SendAsync(mailMessage, cancellationToken);
        await smtpClient.DisconnectAsync(true, cancellationToken);
    }
}