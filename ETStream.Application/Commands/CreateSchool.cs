using System.Text.Json.Serialization;
using ETStream.Application.Seed;

namespace ETStream.Application.Commands
{
    public readonly record struct CreateSchoolProperties
    {
        public readonly string Description { get; init; }
    }

    public class CreateSchool : Command<CreateSchoolProperties>
    {
        public CreateSchool(CreateSchoolProperties props) : base(props)
        {
        }
    }
}