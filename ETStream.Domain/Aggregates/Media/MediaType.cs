namespace ETStream.Domain.Aggregates.Media
{
    public enum MediaTypeEnum
    {
        VIDEO = 1,
        POST
    }

    public class MediaType
    {
        private static readonly MediaType _videoMedia = new(1, nameof(MediaTypeEnum.VIDEO));
        private static readonly MediaType _postMedia = new(2, nameof(MediaTypeEnum.POST));

        public int Id { get; private set; }
        public string Description { get; private set; }

        private MediaType(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public static MediaType GetInstance(MediaTypeEnum type)
        {
            return type switch
            {
                MediaTypeEnum.VIDEO => _videoMedia,
                MediaTypeEnum.POST => _postMedia,
                _ => throw new InvalidOperationException($"Invalid enum name {nameof(type)}."),
            };
        }
    }
}