using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices")
                .HasKey(d => d.DeviceID);

            //Relationship Device to Asset 1:N
            builder.HasMany(d => d.Assets)
                .WithOne(a => a.Device)
                .HasForeignKey(a => a.DeviceID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
