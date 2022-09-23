namespace Thread.Modules.UserAccess.Application.Exceptions;

internal class SpecNotFoundException : Exception
{
    public SpecNotFoundException(string details, string specName) : base(specName)
    {
        Details = details;
    }
    
    public string Details { get; }
}