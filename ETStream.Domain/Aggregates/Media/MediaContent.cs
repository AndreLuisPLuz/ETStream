namespace ETStream.Domain.Aggregates.Media
{
    public enum MediaContentType
    {
        HEADER,
        BINARY
    }

    public class MediaContent
    {
        public int ContentNumber { get; private set; }
        public MediaContentType Type { get; private set; }

        private readonly Byte[]? _binaryData = null;
        public Byte[]? BinaryData => _binaryData;

        protected MediaContent() { }

        public MediaContent(int contentNumber, MediaContentType type)
        {
            ContentNumber = contentNumber;
            Type = type;
        }
    }
}