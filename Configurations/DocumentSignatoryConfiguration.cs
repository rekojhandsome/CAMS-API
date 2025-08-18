using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAMS_API.Configuration
{
    public class DocumentSignatoryConfiguration : IEntityTypeConfiguration<DocumentSignatory>
    {
        public void Configure(EntityTypeBuilder<DocumentSignatory> builder)
        {
            builder.ToTable("DocumentSignatories")
                .HasKey(ds => new
                {
                    ds.DocumentID,
                    ds.DepartmentID,
                    ds.SignatoryID,
                });
        }
    }
}
