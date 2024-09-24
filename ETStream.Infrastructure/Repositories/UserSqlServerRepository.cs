using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Contracts;
using ETStream.Infrastructure.Sources;
using Microsoft.EntityFrameworkCore;

namespace ETStream.Infrastructure.Repositories
{
    public class UserSqlServerRepository :
            SqlServerRepository<UserEntity>,
            IUserRepository
    {
        public UserSqlServerRepository(ETStreamContext context) : base(context) { }

        public async Task<UserEntity?> FindByEmailAsync(string email)
        {
            return await _rootSet.SingleOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}