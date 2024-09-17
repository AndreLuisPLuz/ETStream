using ETStream.Domain.Aggregates.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations
{
    public class MediaEntityTypeConfiguration : IEntityTypeConfiguration<MediaEntity>
    {
        public void Configure(EntityTypeBuilder<MediaEntity> mediaConfiguration)
        {
            mediaConfiguration.ToTable("medias");
            mediaConfiguration.Ignore(m => m.DomainEvents);
        }
    }
}