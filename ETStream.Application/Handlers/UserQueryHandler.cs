using ETStream.Application.Errors;
using ETStream.Application.Queries;
using ETStream.Application.Seed;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Seed;

namespace ETStream.Application.Handlers
{
    public class UserQueryHandler : IQueryHandler<UserDetails?, GetUserDetailsProps>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IRepository<SchoolEntity> _schoolRepository;

        public UserQueryHandler(
                IRepository<UserEntity> repository,
                IRepository<SchoolEntity> schoolRepository)
        {
            _repository = repository;
            _schoolRepository = schoolRepository;
        }

        public async Task<UserDetails?> HandleAsync(Query<GetUserDetailsProps, UserDetails?> query)
        {
            var user = await _repository.FindByIdAsync(query.Properties.UserId)
                    ?? throw new NotFoundException("User not found.");

            var school = await _schoolRepository.FindByIdAsync(user.SchoolId)
                    ?? throw new NotFoundException("School not found.");
            
            return new UserDetails
            {
                Email = user.Email,
                Username = user.Username,
                School = new SchoolDetails
                {
                    Description = school.Description,
                }
            };
        }
    }
}