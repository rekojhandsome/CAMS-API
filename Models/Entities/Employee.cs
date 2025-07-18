using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Models.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Suffix { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Gender { get; set; }
        public int ContactNo { get; set; }
        public required string Email { get; set; }
        public required DateTime DateHired { get; set; }
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime DateCreated { get; set; }
        public Department? Department { get; set; }
        public Position? Position { get; set; }
        public Account? Account { get; set; }

    }
}
