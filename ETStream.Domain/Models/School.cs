namespace ETStream.Domain.Models
{
    public class School
    {
        public Guid Id { get; private set; }
        public string Description { get; set; }

        protected School() { }

        public School(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}