namespace Thread.Modules.UserAccess.Application.Features.Registration;

internal sealed class SendConfirmationEmail : IDomainEventHandler<NewUserRegisteredDomainEvent>
{
    private readonly ILinkProvider _linkProvider;
    private readonly IEmailSender _emailSender;

    public SendConfirmationEmail( ILinkProvider linkProvider , IEmailSender emailSender)
    {
        _linkProvider = linkProvider;
        _emailSender = emailSender;
    }

    public async Task Handle(NewUserRegisteredDomainEvent @event, CancellationToken cancellationToken)
    {
        var link = _linkProvider.GetUserRegistrationConfirmationLink(@event.ConfirmationToken);
        var content = $"Welcome to Thread application! Please confirm your registration using this {link}.";
        var subject = "Thread - Please confirm your registration.";

        EmailMessage message = new(@event.UserEmail, subject, content);

        await _emailSender.SendAsync(message, cancellationToken);
    }
}