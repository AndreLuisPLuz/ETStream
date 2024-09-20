namespace ETStream.Application.Seed
{
    interface ICommandHandler<TResult, TCommand> where TCommand : Command<Object>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}