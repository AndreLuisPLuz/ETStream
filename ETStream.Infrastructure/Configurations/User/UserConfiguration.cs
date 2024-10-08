using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Aggregates.User;
using ETStream.Infrastructure.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations.User
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> userConfiguration)
        {
            userConfiguration.ToTable("Users");
            userConfiguration.Ignore(u => u.DomainEvents);

            userConfiguration.HasOne<SchoolEntity>()
                    .WithMany()
                    .HasForeignKey(u => u.SchoolId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}