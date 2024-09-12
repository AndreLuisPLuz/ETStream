using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel
{
    public class Member : Entity
    {
        public string UserId { get; private set; }

        private readonly List<ChannelPrivilegeGroup> _privilegeGroups;
        public List<ChannelPrivilegeGroup> PrivilegeGroups => _privilegeGroups;

        public Member() : base() { }

        public Member(string userId) : base()
        {
            UserId = userId;
            _privilegeGroups = new List<ChannelPrivilegeGroup>();
        }
    }
}