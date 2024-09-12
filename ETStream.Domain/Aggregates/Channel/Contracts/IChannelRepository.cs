using ETStream.Domain.Seed;

namespace ETStream.Domain.Aggregates.Channel.Contracts
{
    public interface IChannelRepository : IRepository<ChannelEntity>
    {
        Task<ChannelEntity> AddPrivilegeGroup(
                Guid channelId,
                ChannelPrivilegeGroup newGroup);

        Task<ChannelPrivilegeGroup> EditPrivilegesGroupAsync(
            Guid groupId,
            Privileges privileges);

        Task<bool> DeletePrivilegeGroup(Guid groupId);

        Task<ChannelEntity> UpsertMember(Guid channelId, Member memberInfo);
        
        Task<bool> RemoveMember(Guid userId);
    }
}