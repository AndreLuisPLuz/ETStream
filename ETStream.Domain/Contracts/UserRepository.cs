using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Seed;

namespace ETStream.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<UserEntity?> FindByEmailAsync(string email);
    }
}