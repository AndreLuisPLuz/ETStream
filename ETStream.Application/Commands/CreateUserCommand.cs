using ETStream.Application.Seed;

namespace ETStream.Application.Commands
{
    public readonly record struct CreateUserCommandProperties {
        public required string Username { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required Guid SchoolId { get; init; }
    }

    public class CreateUserCommand : Command<CreateUserCommandProperties>
    {
        public CreateUserCommand(CreateUserCommandProperties props) : base(props) { }
    }
}