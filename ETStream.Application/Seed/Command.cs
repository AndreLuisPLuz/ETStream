namespace ETStream.Application.Seed
{
    public abstract class Command<TProperties>
    {
        public Guid CommandId { get; private set; }
        public TProperties Properties { get; private set; }

        protected Command(TProperties props)
        {
            CommandId = new Guid();
            Properties = props;
        }
    }
}