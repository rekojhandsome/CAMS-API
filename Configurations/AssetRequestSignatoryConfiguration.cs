using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class AssetRequestSignatoryConfiguration : IEntityTypeConfiguration<AssetRequestSignatory>
    {
        public void Configure(EntityTypeBuilder<AssetRequestSignatory> builder)
        {
            builder.ToTable("AssetRequestSignatories")
                 .HasKey(ars => new
                 {
                     ars.AssetRequestID,
                     ars.SequenceID,
                     ars.DepartmentID,
                     ars.PositionID,
                 });

            builder.HasOne(ars => ars.AssetRequestHeader)
                .WithMany(arh => arh.AssetRequestSignatories)
                .HasForeignKey(ars => ars.AssetRequestID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
