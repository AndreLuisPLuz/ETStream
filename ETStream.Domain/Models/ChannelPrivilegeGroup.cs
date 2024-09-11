namespace ETStream.Domain.Models
{
    public class ChannelPrivilegeGroup
    {
        public Guid Id { get; private set; }
        public Channel Channel { get; private set; }

        public ChannelPrivilegeGroup() { }

        public ChannelPrivilegeGroup(Guid id, Channel channel)
        {
            Id = id;
            Channel = channel;
        }
    }
}