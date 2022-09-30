namespace Thread.BuildingBlocks.Infrastructure.DomainEventsDispatcher;

internal sealed class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IMediator _mediator;
    
    public DomainEventsDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchDomainEventsAsync(DbContext dbContext, CancellationToken cancellationToken = default)
    {
        var domainEvents = ListDomainEvents(dbContext);

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }
        
        ClearAllDomainEvents(dbContext);
    }
    
    private IReadOnlyList<IDomainEvent> ListDomainEvents(DbContext dbContext)
    {
        var entries = dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .ToList();

        return entries
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList()
            .AsReadOnly();
    }

    private void ClearAllDomainEvents(DbContext dbContext)
    {
        var entries = dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .ToList();

        entries.ForEach(e => e.Entity.ClearAllDomainEvents());
    }
}