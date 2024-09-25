using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.User
{
    public class UserEntity : Entity
    {
        private NameValue _username;
        private PasswordValue _password;

        public string Username
        {
            get => _username.Value;
            set => _username = NameValue.Create(value);
        }

        public string Password
        {
            get => _password.Value;
            set => _password = PasswordValue.Load(value);
        }

        public string Email { get; private set; }
        
        public Guid SchoolId { get; private set; }

        protected UserEntity() : base() {}

        private UserEntity(
                string username,
                string email,
                string password,
                Guid schoolId,
                Guid? id = null) : base(id)
        {
            Email = email;
            SchoolId = schoolId;

            _username = NameValue.Create(username);
            _password = (id is null)
                ? PasswordValue.CreateForUser(this, password)
                : PasswordValue.Load(password);
        }

        public static UserEntity CreateNew(
                string username,
                string email,
                string password,
                Guid schoolId)
        {
            return new UserEntity(username, email, password, schoolId);
        }

        public static UserEntity Load(
                string username,
                string email,
                string password,
                Guid schooId,
                Guid id)
        {
            return new UserEntity(username, email, password, schooId, id);
        }

        public AuthenticationResult AuthenticateAgainst(string username, string password)
        {
            bool usernameMatches = _username.Value.Equals(username) || Email.Equals(username);
            bool passwordMatches = _password.MatchesAgainst(this, password);

            if (usernameMatches && passwordMatches)
                return new AuthenticationResult.Succeeded(Id);
            
            return new AuthenticationResult.Failed(usernameMatches, passwordMatches);
        }
    }
}