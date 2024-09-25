using ETStream.Domain.Aggregates.User;

namespace ETStream.Application.Errors
{
    public class AuthenticationException : Exception
    {
        public AuthenticationResult.Failed Failure { get; private set; }

        public AuthenticationException(string message, AuthenticationResult.Failed failure) : base(message)
        {
            Failure = failure;
        }
    }
}