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

            userConfiguration.Property(u => u.Password)
                    .HasConversion(
                        p => p.Value,
                        p => PasswordValue.Load(p));
            
            userConfiguration.Property(u => u.Username)
                    .HasConversion(
                        n => n.Value,
                        n => Name.Create(n));

            userConfiguration.HasOne<SchoolEntity>()
                    .WithMany()
                    .HasForeignKey(u => u.SchoolId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}