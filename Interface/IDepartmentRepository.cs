using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentAsync(int id);
        Task<Department> CreateDepartmentAsync(Department department);
        void DeleteDepartment(Department department);
    }
}
