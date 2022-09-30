namespace Thread.BuildingBlocks.Application.Contracts;

public interface IDomainEventHandler<in TDomainEvent> : 
    INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}