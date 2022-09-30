namespace Thread.BuildingBlocks.Domain.Contracts;

public interface IDomainRule
{
    string Details { get; }

    bool IsBroken();
}