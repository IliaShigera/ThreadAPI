namespace Thread.Modules.UserAccess.Domain.Configuration;

internal sealed class DomainRuleBrokenException : Exception
{
    public DomainRuleBrokenException(string details, string ruleName) : base(ruleName)
    {
        Details = details;
    }

    public string Details { get; }
}