using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Seed;

namespace ETStream.Domain.Contracts
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> FindByEmailOrUsernameAsync(string email);
    }
}