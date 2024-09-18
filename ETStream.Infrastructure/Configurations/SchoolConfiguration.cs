using ETStream.Domain.Aggregates.School;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<SchoolEntity>
    {
        public void Configure(EntityTypeBuilder<SchoolEntity> schoolConfiguration)
        {
            schoolConfiguration.ToTable("Schools");
            schoolConfiguration.Ignore(s => s.DomainEvents);
        }
    }
}