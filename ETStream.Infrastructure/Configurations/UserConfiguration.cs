using ETStream.Domain.Aggregates.User;
using ETStream.Infrastructure.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> userConfiguration)
        {
            userConfiguration.ToTable("Users");
            userConfiguration.Ignore(u => u.DomainEvents);
        }
    }
}