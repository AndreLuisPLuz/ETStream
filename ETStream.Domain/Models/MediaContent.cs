namespace ETStream.Domain.Models
{
    public enum MediaContentType
    {
        HEADER,
        BINARY
    }

    public class MediaContent
    {
        private readonly Byte[]? _binaryData = null;

        public Guid Id { get; private set; }
        public MediaContentType Type { get; private set; }
        public int Order { get; set; }

        public Byte[]? BinaryData => _binaryData;

        protected MediaContent() { }

        public MediaContent(Guid id, MediaContentType type)
        {
            Id = id;
            Type = type;
        }
    }
}