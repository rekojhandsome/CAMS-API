namespace CAMS_API.Models.DTO.AuthenticationDTO
{
    public class TokenResponseModel
    {
        public  string? Username { get; set; }
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
