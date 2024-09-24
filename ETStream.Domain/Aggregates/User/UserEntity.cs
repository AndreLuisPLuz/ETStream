using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.User
{
    public class UserEntity : Entity
    {
        public Name Username { get; set; }
        public PasswordValue Password { get; set; }
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
            Username = Name.Create(username);

            if (id is null)
            {
                Password = PasswordValue.CreateForUser(this, password);
            }
            else
            {
                Password = PasswordValue.Load(password);
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
            return Password.VerifyAgainst(this, password);
        }
    }
}