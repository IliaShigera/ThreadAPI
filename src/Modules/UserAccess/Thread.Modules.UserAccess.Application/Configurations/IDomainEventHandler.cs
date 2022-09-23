namespace Thread.Modules.UserAccess.Application.Configurations;

public interface IDomainEventHandler<in TDomainEvent> : 
    INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}