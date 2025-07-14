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
                .HasKey(arh => arh.assetRequestID);
        }
    }
}
