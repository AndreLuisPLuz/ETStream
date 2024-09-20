namespace ETStream.Domain.Aggregates.User
{
    public class Name
    {
        public string Value { get; private set; }

        private Name(string name)
        {
            Value = name;
        }

        public static Name Create(string name)
        {
            return new Name(name);
        }
    }
}