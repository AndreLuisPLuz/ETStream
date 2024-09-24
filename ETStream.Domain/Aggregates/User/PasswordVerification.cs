namespace ETStream.Domain.Aggregates.User
{
    public abstract record AuthenticationResult()
    {
        public record Failed() : AuthenticationResult;
        public record Succeeded(Guid UserId) : AuthenticationResult; 
    }
}