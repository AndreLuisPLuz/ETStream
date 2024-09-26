namespace ETStream.Application.Errors
{
    public class InvalidHeadersException : Exception
    {
        public InvalidHeadersException(string message) : base(message) { }
    }
}