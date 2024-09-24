namespace ETStream.Domain.Aggregates.User
{
    public abstract record PasswordVerification()
    {
        public record Failed() : PasswordVerification;
        public record Succeeded(Guid UserId) : PasswordVerification; 
    }
}