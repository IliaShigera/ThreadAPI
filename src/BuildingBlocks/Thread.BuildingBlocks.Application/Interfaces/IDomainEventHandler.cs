using Thread.BuildingBlocks.Domain.Interfaces;

namespace Thread.BuildingBlocks.Application.Interfaces;

public interface IDomainEventHandler<in TDomainEvent> : 
    INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}