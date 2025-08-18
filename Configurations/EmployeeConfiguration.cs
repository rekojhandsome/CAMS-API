using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees")
                .HasKey(e => e.EmployeeID);

            //Relationship ARH to Employee 1:N
            builder.HasMany(a => a.AssetRequestHeaders)
                .WithOne(arh => arh.Employee)
                .HasForeignKey(arh => arh.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
