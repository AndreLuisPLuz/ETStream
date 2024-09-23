using ETStream.Application.Commands;
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

            var school = _schoolRepo.FindByIdAsync(props.SchoolId) 
                    ?? throw new Exception("School not found.");

            var newUser = UserEntity.CreateNew(
                    username: props.Username,
                    email: props.Email,
                    password: props.Password,
                    schoolId: props.SchoolId);

            var savedUser = await _repo.UpsertAsync(newUser);

            return savedUser?.Id ?? null;
        }
    }
}