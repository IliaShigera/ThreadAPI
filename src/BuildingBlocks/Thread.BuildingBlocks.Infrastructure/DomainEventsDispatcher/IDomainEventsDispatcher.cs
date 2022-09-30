namespace Thread.BuildingBlocks.Infrastructure.DomainEventsDispatcher;

public interface IDomainEventsDispatcher
{
    Task DispatchDomainEventsAsync(DbContext dbContext, CancellationToken cancellationToken = default);
}