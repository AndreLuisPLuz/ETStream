using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel
{
    public class ChannelEntity : Entity
    {
        public string Description { get; private set; }
        public string? About { get; private set; }
        
        public Guid SchoolId { get; private set; }

        private readonly List<ChannelPrivilegeGroup> _privilegeGroups;
        public IReadOnlyCollection<ChannelPrivilegeGroup> PrivilegeGroups => _privilegeGroups;

        private readonly List<Member> _members;
        public IReadOnlyCollection<Member> Members => _members;

        protected ChannelEntity() : base() { }

        private ChannelEntity(
                Guid schoolId,
                string description,
                string? about = null,
                List<ChannelPrivilegeGroup>? groups = null,
                List<Member>? members = null,
                Guid? id = null) : base(id)
        {
            SchoolId = schoolId;
            Description = description;
            About = about;

            _privilegeGroups = groups ?? new List<ChannelPrivilegeGroup>();
            _members = members ?? new List<Member>();
        }

        public static ChannelEntity CreateNew(
                Guid schoolId,
                string description,
                string? about = null)
        {
            return new ChannelEntity(schoolId, description, about);
        }
    }
}