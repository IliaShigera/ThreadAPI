namespace Thread.BuildingBlocks.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}