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

        public ETStreamContext() { }

        public ETStreamContext(DbContextOptions<ETStreamContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new ChannelConfiguration());
            modelBuilder.ApplyConfiguration(new ChannelPrivilegeGroupConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}