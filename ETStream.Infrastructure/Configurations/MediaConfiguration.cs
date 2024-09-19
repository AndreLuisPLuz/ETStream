using ETStream.Domain.Aggregates.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<MediaEntity>
    {
        public void Configure(EntityTypeBuilder<MediaEntity> mediaConfiguration)
        {
            mediaConfiguration.ToTable("Medias");
            mediaConfiguration.Ignore(m => m.DomainEvents);

            mediaConfiguration.OwnsOne(m => m.Type);

            mediaConfiguration.OwnsMany(
                m => m.Contents, c => 
                {
                    c.WithOwner().HasForeignKey("MediaId");
                    c.Property<int>("ContentNumber").IsRequired();
                    c.HasKey("MediaId", "ContentNumber");
                });
        }
    }
}