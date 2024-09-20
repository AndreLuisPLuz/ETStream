using ETStream.Domain.Aggregates.Media;
using ETStream.Domain.Aggregates.School;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETStream.Infrastructure.Configurations.Media
{
    public class MediaConfiguration : IEntityTypeConfiguration<MediaEntity>
    {
        public void Configure(EntityTypeBuilder<MediaEntity> mediaConfiguration)
        {
            mediaConfiguration.ToTable("Medias");
            mediaConfiguration.Ignore(m => m.DomainEvents);

            mediaConfiguration.Property(m => m.Type)
                    .HasConversion(
                        t => t.Id,
                        t => MediaType.GetInstance((MediaTypeEnum) t)
                    )
                    .HasColumnName("Type")
                    .HasColumnType("tinyint")
                    .IsRequired();
            
            mediaConfiguration.HasOne<SchoolEntity>()
                    .WithMany()
                    .HasForeignKey(m => m.ChannelId)
                    .OnDelete(DeleteBehavior.Cascade);

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