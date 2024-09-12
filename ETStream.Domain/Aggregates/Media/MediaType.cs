namespace ETStream.Domain.Aggregates.Media
{
    public enum Type
    {
        VIDEO,
        POST
    }

    public class MediaType
    {
        private static readonly MediaType _videoMedia = new(1, nameof(Type.VIDEO));
        private static readonly MediaType _postMedia = new(2, nameof(Type.POST));

        public int Id { get; private set; }
        public string Description { get; private set; }

        private MediaType(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public static MediaType GetInstance(Type type)
        {
            return type switch
            {
                Type.VIDEO => _videoMedia,
                Type.POST => _postMedia,
                _ => throw new InvalidOperationException($"Invalid enum name {nameof(type)}."),
            };
        }
    }
}