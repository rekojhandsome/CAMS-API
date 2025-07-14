using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            dbContext.Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployeeByIDAsync(int id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(e => e.employeeID == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }
    }
}
