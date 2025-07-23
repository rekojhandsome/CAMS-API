namespace CAMS_API.Models.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public required string DepartmentName { get; set; }
        public required string DepartmentCode { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
