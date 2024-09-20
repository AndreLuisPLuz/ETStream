using ETStream.Application.Seed;

namespace ETStream.Application.Commands
{
    public readonly record struct CreateSchoolCommandProperties
    {
        public readonly string Description { get; init; }
    }

    public class CreateSchoolCommand : Command<CreateSchoolCommandProperties>
    {
        public CreateSchoolCommand(CreateSchoolCommandProperties props) : base(props)
        {
        }
    }
}