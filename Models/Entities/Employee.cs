using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Models.Entities
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public DateTime birthDate { get; set; }
        public string gender { get; set; }
        public int contactNo { get; set; }
        public string email { get; set; }
        public DateTime dateHired { get; set; }
        public int positionID { get; set; }
        public int departmentID { get; set; }
        public DateTime dateCreated { get; set; }
        public required Department Department { get; set; }
        public required Position Position { get; set; }
    }
}
