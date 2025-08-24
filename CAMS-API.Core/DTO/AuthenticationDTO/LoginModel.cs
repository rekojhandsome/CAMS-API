namespace CAMS_API.Models.DTO.AuthenticationDTO
{
    public class LoginModel
    {
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
