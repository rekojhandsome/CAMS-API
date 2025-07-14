namespace CAMS_API.Models.Entities
{
    public class Department
    {
        public int departmentID { get; set; }
        public required string departmentName { get; set; }
        public required string departmentCode { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
