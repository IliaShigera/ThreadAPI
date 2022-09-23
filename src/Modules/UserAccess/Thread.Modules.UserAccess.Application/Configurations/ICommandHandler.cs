namespace Thread.Modules.UserAccess.Application.Configurations;

public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand>
    where TCommand: ICommand
{
}