using Microsoft.AspNetCore.Identity;

namespace ETStream.Domain.Aggregates.User
{
    public class PasswordValue
    {
        private static readonly PasswordHasher<UserEntity> _passwordHasher = new();
        private readonly string _value;

        public string Value => _value;

        private PasswordValue(string password)
        {
            _value = password;
        }

        public static PasswordValue CreateForUser(UserEntity user, string password)
        {
            password = _passwordHasher.HashPassword(user, password);
            return new PasswordValue(password);
        }

        public static PasswordValue Load(string password)
        {
            return new PasswordValue(password);
        }

        public bool MatchesAgainst(UserEntity user, string rawPassword)
        {
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, _value, rawPassword);
            
            return verificationResult switch
            {
                PasswordVerificationResult.Success => true,
                _ => false,
            };
        }
    }
}