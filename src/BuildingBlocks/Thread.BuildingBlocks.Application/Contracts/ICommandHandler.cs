namespace Thread.BuildingBlocks.Application.Contracts;

public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand>
    where TCommand: ICommand
{
}