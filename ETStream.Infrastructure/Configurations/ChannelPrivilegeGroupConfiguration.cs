using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using ETStream.Domain.Aggregates.Channel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class ChannelPrivilegeGroupConfiguration : IEntityTypeConfiguration<ChannelPrivilegeGroup>
    {
        public void Configure(EntityTypeBuilder<ChannelPrivilegeGroup> privilegeGroupConfiguration)
        {
            privilegeGroupConfiguration.ToTable("ChannelPrivilegeGroups");
            privilegeGroupConfiguration.Ignore(p => p.DomainEvents);

            privilegeGroupConfiguration.OwnsOne(
                cp => cp.Privileges, navBuilder => navBuilder.ToJson());
        }
    }
}