namespace ETStream.Domain.Aggregates.User
{
    public abstract record AuthenticationResult()
    {
        public record Failed(bool UsernameMatches, bool PasswordMatches) : AuthenticationResult;
        public record Succeeded(Guid UserId) : AuthenticationResult; 
    }
}