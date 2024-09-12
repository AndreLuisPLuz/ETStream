using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel
{
    public class ChannelPrivilegeGroup : Entity
    {
        public string Description { get; set; }
        public required Privileges Privileges { get; set; }

        public ChannelPrivilegeGroup() : base() { }

        public ChannelPrivilegeGroup(string description) : base()
        {
            Description = description;
        }
    }
}