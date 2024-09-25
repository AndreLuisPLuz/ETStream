namespace ETStream.Application.CrossCutting
{
    public record JwtSettings
    {
        public required string SecretKey { get; init; }
    }
}