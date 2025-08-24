using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIDAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<Employee> GetEmployeeProfile(int accountID);
    }
}
