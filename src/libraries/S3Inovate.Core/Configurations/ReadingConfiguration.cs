using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S3Inovate.Core.Models;

namespace S3Inovate.Core.Configurations
{
    public class ReadingConfiguration : IEntityTypeConfiguration<Reading>
    {
        public void Configure(EntityTypeBuilder<Reading> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.BuildingId,
                    x.ObjectId,
                    x.DataFieldId,
                    x.Timestamp
                });

            builder.Property(x => x.Value).HasPrecision(18, 2);
        }
    }
}
