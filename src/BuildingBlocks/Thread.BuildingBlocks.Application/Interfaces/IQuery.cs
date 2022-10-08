namespace Thread.BuildingBlocks.Application.Interfaces;

public interface IQuery<out TResult> : IRequest<TResult>
{
}