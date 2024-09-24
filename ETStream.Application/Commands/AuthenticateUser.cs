using ETStream.Application.Seed;

namespace ETStream.Application.Commands
{
    public readonly record struct AuthenticateUserProperties
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
    }

    public class AuthenticateUser : Command<AuthenticateUserProperties>
    {
        public AuthenticateUser(AuthenticateUserProperties props) : base(props)
        {
        }
    }
}