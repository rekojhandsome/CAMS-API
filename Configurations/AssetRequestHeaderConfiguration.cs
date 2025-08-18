using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class AssetRequestHeaderConfiguration : IEntityTypeConfiguration<AssetRequestHeader>
    {
        public void Configure(EntityTypeBuilder<AssetRequestHeader> builder)
        {
            builder.ToTable("AssetRequestHeaders")
                .HasKey(arh => arh.AssetRequestID);

            builder.HasMany(arh => arh.AssetRequestDetails)
                .WithOne(ard => ard.AssetRequestHeader)
                .HasForeignKey(ard => ard.AssetRequestID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
