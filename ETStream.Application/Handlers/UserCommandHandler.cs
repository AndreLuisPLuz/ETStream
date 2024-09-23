using ETStream.Application.Commands;
using ETStream.Application.Errors;
using ETStream.Application.Seed;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Seed;

namespace ETStream.Application.Handlers
{
    public class UserCommandHandler : ICommandHandler<Guid?, CreateUserProperties>
    {
        private readonly IRepository<UserEntity> _repo;
        private readonly IRepository<SchoolEntity> _schoolRepo;

        public UserCommandHandler(
                IRepository<UserEntity> repository,
                IRepository<SchoolEntity> schoolRepository)
        {
            _repo = repository;
            _schoolRepo = schoolRepository;
        }

        public async Task<Guid?> HandleAsync(Command<CreateUserProperties> command)
        {
            var props = command.Properties;

            var schoolExists = await _schoolRepo.ExistsAsync(props.SchoolId);

            if (!schoolExists)
                throw new NotFoundException("School not found.");

            var newUser = UserEntity.CreateNew(
                    username: props.Username,
                    email: props.Email,
                    password: props.Password,
                    schoolId: props.SchoolId);

            var savedUser = await _repo.UpsertAsync(newUser)
                    ?? throw new UpsertFailException("Could not save user.");

            return savedUser.Id;
        }
    }
}