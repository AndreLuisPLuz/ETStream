 using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Media
{
    public class MediaEntity : Entity
    {
        public MediaType Type { get; private set; }
        public Guid ChannelId { get; private set; }

        private readonly List<MediaContent> _contents;
        public IReadOnlyCollection<MediaContent> Contents => _contents;

        protected MediaEntity() : base() { }

        private MediaEntity(
                MediaType type,
                Guid channelId,
                Guid? id = null) : base(id)
        {
            _contents =  new List<MediaContent>();
            
            ChannelId = channelId;
            Type = type;
        }

        public static MediaEntity CreateNew(MediaType type, Guid channelId)
        {
            return new MediaEntity(type, channelId);
        }
    }
}