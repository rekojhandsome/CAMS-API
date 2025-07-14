using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department")
                .HasKey(d => d.departmentID);

            builder.Property(d => d.departmentID)
                .HasColumnName("DepartmentID")
                .IsRequired();

            builder.Property(d => d.departmentName)
                .HasColumnName("DepartmentName")
               
                .IsRequired();

            builder.Property(d => d.departmentCode)
                .HasColumnName("DepartmentCode")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.departmentID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
