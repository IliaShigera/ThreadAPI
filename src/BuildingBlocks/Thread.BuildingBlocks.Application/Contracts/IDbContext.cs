namespace Thread.BuildingBlocks.Application.Contracts;

public interface IDbContext
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}