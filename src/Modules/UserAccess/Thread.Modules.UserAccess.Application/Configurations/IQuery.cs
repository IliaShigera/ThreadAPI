namespace Thread.Modules.UserAccess.Application.Configurations;

public interface IQuery<out TResult> : IRequest<TResult>
{
}