using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class AssetRequestDetailConfiguration : IEntityTypeConfiguration<AssetRequestDetail>
    {
        public void Configure(EntityTypeBuilder<AssetRequestDetail> builder)
        {
            builder.ToTable("AssetRequestDetail")
                .HasKey(ard => new
                {
                    ard.assetRequestID,
                    ard.sequenceID
                });

            builder.HasOne(ard => ard.AssetRequestHeader)
                .WithMany(ard => ard.AssetRequestDetails)
                .HasForeignKey(ard => ard.assetRequestID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ard => ard.sequenceID)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}
