namespace Thread.Modules.UserAccess.Domain.Configuration;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public Guid Id { get; protected set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);
    
    protected void ClearAllDomainEvents() => _domainEvents.Clear();
    
    protected void CheckRule(IDomainRule rule)
    {
        if (rule.IsBroken())
            throw new DomainRuleBrokenException(rule.Details, nameof(rule));
    }

}