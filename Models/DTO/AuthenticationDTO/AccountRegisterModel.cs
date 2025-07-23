namespace CAMS_API.Models.DTO.AuthenticationDTO
{
    public class AccountRegisterModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int EmployeeID { get; set; }
    }
}
