namespace Domain.Interfaces.CQS
{
    public interface ICommandHandlerWithVoidTResult<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
