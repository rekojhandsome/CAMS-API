using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Assets")
                .HasKey(a => a.AssetID);

            
        }
    }
}
