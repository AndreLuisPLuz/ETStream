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

        public PasswordVerification VerifyPassword(string password)
        {
            return _password.VerifyAgainst(this, password);
        }
    }
}