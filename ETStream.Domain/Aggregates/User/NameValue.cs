namespace ETStream.Domain.Aggregates.User
{
    public class NameValue
    {
        public string Value { get; private set; }

        private NameValue(string name)
        {
            Value = name;
        }

        public static NameValue Create(string name)
        {
            return new NameValue(name);
        }
    }
}