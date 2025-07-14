using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Device")
                .HasKey(d => d.deviceID);

            builder.Property(d => d.deviceID)
                .HasColumnName("DeviceID");

            builder.Property(d => d.deviceName)
                .HasColumnName("DeviceName")
                .IsRequired();

            builder.Property(d => d.deviceType)
                .HasColumnName("DeviceType")
                .IsRequired();

            builder.Property(d => d.brand)
                .HasColumnName("Brand")
                .IsRequired();

            builder.Property(d => d.model)
                .HasColumnName("Model")
                .IsRequired();
        }
    }
}
