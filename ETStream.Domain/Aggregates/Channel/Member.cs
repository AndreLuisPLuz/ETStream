using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel
{
    public class Member
    {
        public Guid UserId { get; private set; }

        private readonly List<ChannelPrivilegeGroup> _privilegeGroups;
        public List<ChannelPrivilegeGroup> PrivilegeGroups => _privilegeGroups;

        protected Member() { }

        public Member(
                Guid userId,
                List<ChannelPrivilegeGroup>? groups = null)
        {
            UserId = userId;
            _privilegeGroups = groups ?? new List<ChannelPrivilegeGroup>();
        }
    }
}