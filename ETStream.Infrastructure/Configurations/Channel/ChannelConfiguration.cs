using ETStream.Domain.Aggregates.Channel;
using ETStream.Domain.Aggregates.School;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations.Channel
{
    public class ChannelConfiguration : IEntityTypeConfiguration<ChannelEntity>
    {
        public void Configure(EntityTypeBuilder<ChannelEntity> channelConfiguration)
        {
            channelConfiguration.ToTable("Channels");
            channelConfiguration.Ignore(c => c.DomainEvents);

            channelConfiguration.HasOne<SchoolEntity>()
                    .WithMany()
                    .HasForeignKey(c => c.SchoolId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            channelConfiguration.HasMany(c => c.PrivilegeGroups)
                .WithOne()
                .HasForeignKey("ChannelId");

            channelConfiguration.OwnsMany(
                c => c.Members, m =>
                {
                    m.WithOwner().HasForeignKey("ChannelId");
                    m.Property<Guid>("UserId").IsRequired();
                    m.HasKey("ChannelId", "UserId");

                    m.HasOne<ChannelPrivilegeGroup>()
                            .WithMany()
                            .HasForeignKey(m => m.ChannelPrivilegeGroupId)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}