namespace ETStream.Application.Seed
{
    abstract class Command<TProperties>
    {
        public Guid CommandId { get; private set; }
        public TProperties Properties { get; private set; }

        protected Command(TProperties props)
        {
            Properties = props;
        }
    }
}