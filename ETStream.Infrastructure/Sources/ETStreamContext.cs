using ETStream.Domain.Aggregates.Channel;
using ETStream.Domain.Aggregates.Media;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Aggregates.User;
using Microsoft.EntityFrameworkCore;

namespace ETStream.Infrastructure.Sources
{
    public class ETStreamContext : DbContext
    {
        public DbSet<UserEntity> users;
        public DbSet<SchoolEntity> schools;
        public DbSet<ChannelEntity> channels;
        public DbSet<ChannelPrivilegeGroup> channelPrivilegeGroups;
        public DbSet<Member> members;
    }
}