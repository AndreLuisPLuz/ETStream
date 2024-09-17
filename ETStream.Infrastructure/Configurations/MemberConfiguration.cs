using ETStream.Domain.Aggregates.Channel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> memberConfiguration)
        {
            memberConfiguration.ToTable("members");
            memberConfiguration.Ignore(m => m.DomainEvents);
        }
    }
}