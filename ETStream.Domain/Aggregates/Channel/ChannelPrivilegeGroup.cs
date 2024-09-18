using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel
{
    public class ChannelPrivilegeGroup : Entity
    {
        public string Description { get; private set; }
        public Privileges Privileges { get; private set; }

        protected ChannelPrivilegeGroup() : base() { }

        private ChannelPrivilegeGroup(
                string description,
                Privileges privileges,
                Guid? id = null) : base(id)
        {
            Description = description;
            Privileges = privileges;
        }

        public static ChannelPrivilegeGroup CreateNew(
                string description,
                Privileges privileges)
        {
            return new ChannelPrivilegeGroup(description, privileges);
        }
    }
}