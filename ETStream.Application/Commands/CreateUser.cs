using ETStream.Application.Seed;

namespace ETStream.Application.Commands
{
    public readonly record struct CreateUserProperties {
        public required string Username { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required Guid SchoolId { get; init; }
    }

    public class CreateUser : Command<CreateUserProperties>
    {
        public CreateUser(CreateUserProperties props) : base(props) { }
    }
}