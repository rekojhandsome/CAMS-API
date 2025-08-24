namespace CAMS_API.Models.DTO.EmployeeDTO
{
    public class EmployeeModel
    {
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
    }
}
