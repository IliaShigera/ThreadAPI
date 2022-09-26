namespace Thread.Modules.UserAccess.Infrastructure.DomainEventsDispatcher;

internal interface IDomainEventsDispatcher
{
    Task DispatchDomainEventsAsync(UserAccessDbContext dbContext, CancellationToken cancellationToken = default);
}