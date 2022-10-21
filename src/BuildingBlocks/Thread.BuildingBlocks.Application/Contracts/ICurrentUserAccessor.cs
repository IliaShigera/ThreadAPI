namespace Thread.BuildingBlocks.Application.Contracts;

public interface ICurrentUserAccessor
{
    string Email { get; }
}