using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIDAsync(int id);
        Task<Department> CreateDepartmentAsync(Department department);
        void DeleteDepartment(Department department);

        Task<Department> GetDepartmentByEmployeeAsync(int departmentID);
    }
}
