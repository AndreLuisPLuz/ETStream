using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel
{
    public class ChannelEntity : Entity
    {
        public string Description { get; private set; }
        public string? About { get; private set; }

        private readonly List<ChannelPrivilegeGroup> _privilegeGroups;
        public IReadOnlyCollection<ChannelPrivilegeGroup> PrivilegeGroups => _privilegeGroups;

        private readonly List<Member> _members;
        public IReadOnlyCollection<Member> Members => _members;

        protected ChannelEntity() : base() { }

        public ChannelEntity(string description, string? about = null) : base()
        {
            Description = description;
            About = about;

            _privilegeGroups = new();
        }
    }
}