using ETStream.Domain.Seed;
using ETStream.Infrastructure.Sources;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ETStream.Infrastructure.Repositories
{
    public class SqlServerRepository<TEntity> : IRepository<TEntity>
            where TEntity : Entity
    {
        protected readonly ETStreamContext _context;
        protected readonly DbSet<TEntity> _rootSet;

        public SqlServerRepository(ETStreamContext context)
        {
            _context = context;
            _rootSet =_context.Set<TEntity>();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _rootSet.AnyAsync(e => e.Id.Equals(id));
        }

        public async Task<TEntity?> FindByIdAsync(Guid id)
        {
            return await _rootSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<TEntity> UpsertAsync(TEntity entity)
        {
            bool entityExists = await _rootSet.AnyAsync(e => e.Id.Equals(entity.Id));

            TEntity? foundEntity = entityExists
                    ? await _rootSet.SingleOrDefaultAsync(e => e.Id.Equals(entity.Id))
                    : _rootSet.Add(entity).Entity;
            
            if (foundEntity is null)
                throw new InvalidDataException($"Invalid state for {entity.GetType().FullName} entity. State: {JsonConvert.SerializeObject(entity)}");
            
            _context.Entry(foundEntity).CurrentValues.SetValues(foundEntity);

            await _context.SaveChangesAsync();
            return foundEntity;
        }
    }
}