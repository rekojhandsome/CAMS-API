namespace CAMS_API.Models.DTO.AuthenticationDTO
{
    public class AuthenticationModel
    {
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string Role { get; set; } = string.Empty;
        public int employeeID { get; set; }
    }
}
