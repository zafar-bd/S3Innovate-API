using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S3Inovate.Core.Models;

namespace S3Inovate.Core.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder
                .Property(x => x.Location)
                .IsRequired(false)
                .HasColumnType("VARCHAR(50)");

            builder.HasIndex(x => new { x.Location, x.Name }).IsUnique();
        }
    }
}
