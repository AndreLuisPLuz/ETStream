using Microsoft.AspNetCore.Identity;

namespace ETStream.Domain.Aggregates.User
{
    public class PasswordValue
    {
        private static readonly PasswordHasher<UserEntity> _passwordHasher = new();
        private readonly UserEntity _user;
        private readonly string _value;

        public string Value => _value;

        private PasswordValue(UserEntity user, string password)
        {
            _user = user;
            _value = password;
        }

        public static PasswordValue CreateForUser(UserEntity user, string password)
        {
            password = _passwordHasher.HashPassword(user, password);
            return new PasswordValue(user, password);
        }

        public static PasswordValue LoadForUser(UserEntity user, string password)
        {
            return new PasswordValue(user, password);
        }

        public PasswordVerification VerifyAgainst(string rawPassword)
        {
            var verificationResult = _passwordHasher.VerifyHashedPassword(_user, _value, rawPassword);
            
            return verificationResult switch
            {
                PasswordVerificationResult.Success => new PasswordVerification.Succeeded(_user.Id),
                _ => new PasswordVerification.Failed(),
            };
        }
    }
}