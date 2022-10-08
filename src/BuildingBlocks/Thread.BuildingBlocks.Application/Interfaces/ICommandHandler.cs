namespace Thread.BuildingBlocks.Application.Interfaces;

public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand>
    where TCommand: ICommand
{
}