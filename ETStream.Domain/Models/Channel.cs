namespace ETStream.Domain.Models
{
    public class Channel
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public string? About { get; private set; }

        protected Channel() { }

        public Channel(Guid id, string description, string? about = null)
        {
            Id = id;
            Description = description;
            About = about;
        }
    }
}