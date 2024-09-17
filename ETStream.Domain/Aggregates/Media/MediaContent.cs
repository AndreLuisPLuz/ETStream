namespace ETStream.Domain.Aggregates.Media
{
    public enum MediaContentType
    {
        HEADER,
        BINARY
    }

    public class MediaContent
    {
        public MediaContentType Type { get; private set; }

        private readonly Byte[]? _binaryData = null;
        public Byte[]? BinaryData => _binaryData;

        protected MediaContent() { }

        public MediaContent(Guid id, MediaContentType type)
        {
            Type = type;
        }
    }
}