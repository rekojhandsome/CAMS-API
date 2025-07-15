using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            await dbContext.Departments.AddAsync(department);
            return department;
        }

        public void DeleteDepartment(Department department)
        {
            dbContext.Departments.Remove(department);
        }

        public async Task<Department> GetDepartmentByIDAsync(int id)
        {
            return await dbContext.Departments.FirstOrDefaultAsync(d => d.departmentID == id);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await dbContext.Departments.ToListAsync();
        }
    }
}
