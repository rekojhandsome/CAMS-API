using CAMS_API.CAMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory")
                .HasKey(i => i.InventoryID);

            builder.HasOne(i => i.Asset)
                .WithOne(a => a.Inventory)
                .HasForeignKey<Inventory>(i => i.AssetID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
