using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Seed;
using ETStream.Infrastructure.Sources;

namespace ETStream.Infrastructure.Repositories
{
    public class SqlServerSchoolRepository : SqlServerRepository<SchoolEntity>
    {
        public SqlServerSchoolRepository(ETStreamContext context) : base(context) { }
    }
}