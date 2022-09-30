namespace Thread.BuildingBlocks.Domain.Exceptions;

public sealed class DomainRuleBrokenException : Exception
{
    public DomainRuleBrokenException(string details, string ruleName) : base(ruleName)
    {
        Details = details;
    }

    public string Details { get; }
}