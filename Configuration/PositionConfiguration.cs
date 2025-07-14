using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position")
                .HasKey(p => p.positionID);

            builder.Property(p => p.positionID)
                .HasColumnName("PositionID");

            builder.Property(p => p.positionName)
                .HasColumnName("PositionName")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.positionID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
