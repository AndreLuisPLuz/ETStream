namespace ETStream.Application.Seed
{
    public interface IQueryHandler<TReturn, TProperties>
    {
        Task<TReturn> HandleAsync(Query<TProperties, TReturn> query);
    }
}