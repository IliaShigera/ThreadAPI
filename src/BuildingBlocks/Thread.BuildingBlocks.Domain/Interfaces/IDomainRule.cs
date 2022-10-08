namespace Thread.BuildingBlocks.Domain.Interfaces;

public interface IDomainRule
{
    string Details { get; }

    bool IsBroken();
}