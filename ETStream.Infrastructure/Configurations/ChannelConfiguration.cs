using ETStream.Domain.Aggregates.Channel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<ChannelEntity>
    {
        public void Configure(EntityTypeBuilder<ChannelEntity> channelConfiguration)
        {
            channelConfiguration.ToTable("Channels");
            channelConfiguration.Ignore(c => c.DomainEvents);

            channelConfiguration.OwnsMany(
                c => c.Members, m =>
                {
                    m.WithOwner().HasForeignKey("ChannelId");
                    m.Property<Guid>("UserId").IsRequired();
                    m.HasKey("ChannelId", "UserId");
                });
        }
    }
}