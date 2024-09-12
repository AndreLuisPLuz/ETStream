using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Media
{
    public class Media : Entity
    {
        public MediaType Type { get; private set; }
        public Guid ChannelId { get; private set; }

        private readonly List<MediaContent> _contents;
        public IReadOnlyCollection<MediaContent> Contents => _contents;

        protected Media() : base() { }

        public Media(Guid channelId, MediaType type) : base()
        {
            _contents =  new List<MediaContent>();
            
            ChannelId = channelId;
            Type = type;
        }
    }
}