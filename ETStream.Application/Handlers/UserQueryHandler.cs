using ETStream.Application.Queries;
using ETStream.Application.Seed;
using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Seed;

namespace ETStream.Application.Handlers
{
    public class UserQueryHandler : IQueryHandler<UserDetails?, GetUserDetailsProps>
    {
        private IRepository<UserEntity> _repository;

        public UserQueryHandler(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<UserDetails?> HandleAsync(Query<GetUserDetailsProps, UserDetails?> query)
        {
            var user = await _repository.FindByIdAsync(query.Properties.UserId);

            if (user is null)
                return null;
            
            return new UserDetails
            {
                Email = user.Email,
                Username = user.Username,
                School = new SchoolDetails
                {
                    Description = "Blank",
                }
            };
        }
    }
}