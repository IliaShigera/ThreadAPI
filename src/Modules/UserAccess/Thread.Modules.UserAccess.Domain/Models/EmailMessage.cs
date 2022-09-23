namespace Thread.Modules.UserAccess.Domain.Models;

public struct EmailMessage
{
    public EmailMessage(string to, string subject, string content)
    {
        To = to;
        Subject = subject;
        Content = content;
    }

    public string To;
    public string Subject;
    public string Content;
}