using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.User
{
    public class UserEntity : Entity
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserEntity() : base() { }

        public UserEntity(string username, string email, string password) {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}