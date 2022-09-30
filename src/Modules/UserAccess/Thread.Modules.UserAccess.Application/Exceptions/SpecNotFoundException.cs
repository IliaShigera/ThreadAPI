namespace Thread.Modules.UserAccess.Application.Exceptions;

public class SpecNotFoundException : Exception
{
    public SpecNotFoundException(string details, string specName) : base(specName)
    {
        Details = details;
    }
    
    public string Details { get; }
}