using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.User
{
    public class UserEntity : Entity
    {
        private Name _username;
        private PasswordValue _password;

        public string Username => _username.Value;
        public string Password => _password.Value;
        public string Email { get; private set; }
        
        public Guid SchoolId { get; private set; }

        protected UserEntity() : base() { }

        private UserEntity(
                string username,
                string email,
                string password,
                Guid schoolId,
                Guid? id = null) : base(id)
        {
            Email = email;
            SchoolId = schoolId;
            _username = Name.Create(username);

            if (id is null)
            {
                _password = PasswordValue.CreateForUser(this, password);
            }
            else
            {
                _password = PasswordValue.LoadForUser(this, password);
            }
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
            return _password.VerifyAgainst(password);
        }
    }
}