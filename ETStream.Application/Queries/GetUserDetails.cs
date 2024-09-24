using ETStream.Application.Seed;

namespace ETStream.Application.Queries
{
    public readonly record struct GetUserDetailsProps
    {
        public required readonly Guid UserId { get; init; }
    }

    public readonly record struct UserDetails
    {
        public required readonly Guid Id { get; init; }
        public required readonly string Username { get; init; }
        public required readonly string Email { get; init; }
        public required readonly SchoolDetails School { get; init; }
    }

    public class GetUserDetails : Query<GetUserDetailsProps, UserDetails>
    {
        public GetUserDetails(GetUserDetailsProps props) : base(props)
        {
        }
    }
}