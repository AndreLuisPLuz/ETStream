namespace ETStream.Application.Seed
{
    interface ICommandHandler<TResult, TProperties>
    {
        Task<TResult> HandleAsync(Command<TProperties> command);
    }
}