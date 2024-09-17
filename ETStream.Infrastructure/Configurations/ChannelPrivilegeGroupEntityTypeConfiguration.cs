using ETStream.Domain.Aggregates.Channel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class ChannelPrivilegeGroupEntityTypeConfiguration : IEntityTypeConfiguration<ChannelPrivilegeGroup>
    {
        public void Configure(EntityTypeBuilder<ChannelPrivilegeGroup> privilegeGroupConfiguration)
        {
            privilegeGroupConfiguration.ToTable("channel_privilege_group");
            privilegeGroupConfiguration.Ignore(p => p.DomainEvents);
        }
    }
}