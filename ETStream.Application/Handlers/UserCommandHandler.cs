using ETStream.Application.Commands;
using ETStream.Application.Seed;
using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Seed;

namespace ETStream.Application.Handlers
{
    public class UserCommandHandler : ICommandHandler<Guid?, CreateUserCommandProperties>
    {
        private readonly IRepository<UserEntity> _repository;

        public UserCommandHandler(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Guid?> HandleAsync(Command<CreateUserCommandProperties> command)
        {
            var props = command.Properties;
            var newUser = UserEntity.CreateNew(
                username: props.Username,
                email: props.Email,
                password: props.Password,
                schoolId: new Guid(props.SchoolId));

            var savedUser = await _repository.UpsertAsync(newUser);

            return savedUser?.Id ?? null;
        }
    }
}