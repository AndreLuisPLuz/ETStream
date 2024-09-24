using ETStream.Application.Seed;

namespace ETStream.Application.Queries
{
    public readonly record struct GetSchoolDetailsProps
    {
        public required readonly Guid SchoolId { get; init; }
    }

    public readonly record struct SchoolDetails
    {
        public required readonly Guid Id { get; init; }
        public required readonly string Description { get; init; }
    }

    public class GetSchoolDetails : Query<GetSchoolDetailsProps, SchoolDetails>
    {
        public GetSchoolDetails(GetSchoolDetailsProps props) : base(props)
        {
        }
    }
}