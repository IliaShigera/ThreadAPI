namespace Thread.Modules.UserAccess.Domain.Configuration;

public interface IDomainRule
{
    string Details { get; }

    bool IsBroken();
}