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
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SchoolEntity> Schools { get; set; }
        public DbSet<ChannelEntity> Channels { get; set; }
        public DbSet<ChannelPrivilegeGroup> ChannelPrivilegeGroups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MediaEntity> Medias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChannelEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChannelPrivilegeGroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());
        }
    }
}