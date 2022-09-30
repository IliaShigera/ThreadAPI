namespace Thread.BuildingBlocks.Application.Exceptions;

public sealed class SpecNotFoundException : Exception
{
    public SpecNotFoundException(string details, string specName) : base(specName)
    {
        Details = details;
    }
    
    public string Details { get; }
}