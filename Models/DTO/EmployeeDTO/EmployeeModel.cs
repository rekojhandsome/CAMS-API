namespace CAMS_API.Models.DTO.EmployeeDTO
{
    public class EmployeeModel
    {
        public required string firstName { get; set; }
        public string? middleName { get; set; }
        public required string lastName { get; set; }
        public string? suffix { get; set; }
        public required DateTime birthDate { get; set; }
        public required string gender { get; set; }
        public int contactNo { get; set; }
        public required string email { get; set; }
        public required DateTime dateHired { get; set; }
        public int positionID { get; set; }
        public int departmentID { get; set; }
    }
}
