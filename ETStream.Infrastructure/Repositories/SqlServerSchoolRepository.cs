using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Seed;

namespace ETStream.Infrastructure.Repositories
{
    public class SqlServerSchoolRepository : IRepository<SchoolEntity>
    {
        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolEntity> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolEntity> UpsertAsync(SchoolEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}