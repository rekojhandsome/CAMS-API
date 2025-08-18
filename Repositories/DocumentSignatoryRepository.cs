using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CAMS_API.Repository
{
    public class DocumentSignatoryRepository : IDocumentSignatoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DocumentSignatoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<DocumentSignatory>> GetDocumentSignatoryAsync(int departmentID)
        {
            return await dbContext.DocumentSignatories.Where(ds => ds.DepartmentID == departmentID && ds.IsActive)
                .OrderBy(ds => ds.Level)
                .ToListAsync();
        }
    }
}
