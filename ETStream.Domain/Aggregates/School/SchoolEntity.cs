using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.School
{
    public class SchoolEntity : Entity
    {
        public string Description { get; set; }

        protected SchoolEntity() { }

        private SchoolEntity(string description, Guid? id = null) : base(id)
        {
            Description = description;
        }

        public static SchoolEntity CreateNew(string description)
        {
            return new SchoolEntity(description);
        }
    }
}