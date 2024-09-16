using ETStream.Domain.Aggregates.Channel;
using ETStream.Domain.Aggregates.Media;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Aggregates.User;
using ETStream.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ETStream.Infrastructure.Sources
{
    public class ETStreamContext : DbContext
    {
        public DbSet<UserEntity> users { get; set; }
        public DbSet<SchoolEntity> schools { get; set; }
        public DbSet<ChannelEntity> channels { get; set; }
        public DbSet<ChannelPrivilegeGroup> channelPrivilegeGroups { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<MediaEntity> medias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolEntityTypeConfiguration());
        }
    }
}