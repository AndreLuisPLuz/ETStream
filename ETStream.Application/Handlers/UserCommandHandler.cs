using ETStream.Application.Commands;
using ETStream.Application.CrossCutting;
using ETStream.Application.Errors;
using ETStream.Application.Seed;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Contracts;
using ETStream.Domain.Seed;

namespace ETStream.Application.Handlers
{
    public class UserCommandHandler :
            ICommandHandler<Guid?, CreateUserProperties>,
            ICommandHandler<string, AuthenticateUserProperties>
    {
        private readonly IUserRepository _repo;
        private readonly IRepository<SchoolEntity> _schoolRepo;
        private readonly JwtService _jwtService;

        public UserCommandHandler(
                IUserRepository repository,
                IRepository<SchoolEntity> schoolRepository,
                JwtService jwtService)
        {
            _repo = repository;
            _schoolRepo = schoolRepository;
            _jwtService = jwtService;
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

        public async Task<string> HandleAsync(Command<AuthenticateUserProperties> command)
        {
            var props = command.Properties;

            var user = await _repo.FindByEmailOrUsernameAsync(props.Username)
                    ?? throw new NotFoundException("Matching user not found.");
            
            var authResult = user.AuthenticateAgainst(props.Username, props.Password);

            return authResult switch
            {
                AuthenticationResult.Succeeded s => _jwtService.GenerateToken(s),
                AuthenticationResult.Failed f => throw new AuthenticationException("Unable to authenticate.", f),
                _ => throw new Exception("Unknown error when generating JWT.")
            };
        }
    }
}