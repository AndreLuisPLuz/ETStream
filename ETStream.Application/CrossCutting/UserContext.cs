namespace ETStream.Application.CrossCutting
{
    public readonly record struct ContextData
    {
        public required Guid UserId { get; init; }
    }

    public class UserContext
    {
        private ContextData _data;

        public Guid UserId => _data.UserId;

        public void Fill(ContextData data)
        {
            _data = data;
        }
    }
}