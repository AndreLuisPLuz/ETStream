using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.User
{
    public class UserEntity : Entity
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Guid SchoolId { get; private set; }

        protected UserEntity() : base() { }

        private UserEntity(
                string username,
                string email,
                string password,
                Guid schoolId,
                Guid? id = null) : base(id)
        {
            Username = username;
            Email = email;
            Password = password;
            SchoolId = schoolId;
        }

        public static UserEntity CreateNew(
                string username,
                string email,
                string password,
                Guid schoolId
        ) {
            return new UserEntity(username, email, password, schoolId);
        }
    }
}