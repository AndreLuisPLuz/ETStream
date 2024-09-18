using ETStream.Domain.Seed;

namespace ETStream.Infrastructure.Repositories
{
    public abstract class BaseSqlServerRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}