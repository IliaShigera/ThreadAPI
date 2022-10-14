namespace Thread.Modules.UserAccess.Application.Features.Registration;

internal sealed class SendConfirmationEmail : IDomainEventHandler<NewUserRegisteredDomainEvent>
{
    private readonly IEmailSender _emailSender;

    public SendConfirmationEmail(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task Handle(NewUserRegisteredDomainEvent @event, CancellationToken cancellationToken)
    {
        // todo: create link from configuration
        var link = $"<a href=\"{@event.ConfirmationToken}\">link</a>";
        var content = $"Welcome to Thread application! Please confirm your registration using this {link}.";
        var subject = "Thread - Please confirm your registration.";

        EmailMessage message = new(@event.UserEmail, subject, content);

        await _emailSender.SendAsync(message, cancellationToken);
    }
}