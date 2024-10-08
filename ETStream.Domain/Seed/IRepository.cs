namespace ETStream.Domain.Seed
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<bool> ExistsAsync(Guid id);
        Task<TEntity?> FindByIdAsync(Guid id);
        Task<TEntity> UpsertAsync(TEntity entity);
    }
}