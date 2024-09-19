using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel
{
    public class Member
    {
        public Guid UserId { get; private set; }
        public Guid ChannelPrivilegeGroupId { get; private set; }

        protected Member() { }

        public Member(
                Guid userId,
                Guid channelPrivilegeGroupId)
        {
            UserId = userId;
            ChannelPrivilegeGroupId = channelPrivilegeGroupId;
        }
    }
}