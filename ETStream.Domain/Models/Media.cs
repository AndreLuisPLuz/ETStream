namespace ETStream.Domain.Models
{
    public enum MediaType
    {
        VIDEO,
        POST
    }

    public class Media
    {
        public Guid Id { get; private set; }
        public MediaType Type { get; private set; }
        public Channel Channel { get; private set; }
        
        protected Media() { }

        public Media(Guid id, MediaType type, Channel channel)
        {
            Id = id;
            Type = type;
            Channel = channel;
        }
    }
}