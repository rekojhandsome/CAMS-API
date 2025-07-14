using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Asset")
                .HasKey(a => a.assetID);

            builder.Property(a => a.assetID)
                .HasColumnName("AssetID");

            builder.Property(a => a.deviceID)
                .HasColumnName("DeviceID");
               

            builder.Property(a => a.assetTag)
                .HasColumnName("AssetTag")
                .IsRequired();

            builder.Property(a => a.serialNumber)
                .HasColumnName("SerialNumber")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(a => a.dateAcquired)
                .HasColumnName("DateAcquired")
                .HasColumnType("datetime");

            builder.Property(a => a.price)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.status)
                .HasColumnName("Status")
                .IsRequired();

            //Relationship Device to Asset 1:N
            builder.HasOne(a => a.Device)
                .WithMany(d => d.Assets)
                .HasForeignKey(a => a.deviceID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
