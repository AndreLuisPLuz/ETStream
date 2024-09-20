namespace ETStream.Application.Seed
{
    public abstract class Query<TProperties, TReturn>
    {
        public readonly Guid QueryId;
        public readonly TProperties Properties;

        public Query(TProperties props)
        {
            QueryId = new Guid();
            Properties = props;
        }
    }
}