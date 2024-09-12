using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.School
{
    public class SchoolEntity : Entity
    {
        public string Description { get; set; }

        protected SchoolEntity() { }

        public SchoolEntity(string description)
        {
            Description = description;
        }
    }
}