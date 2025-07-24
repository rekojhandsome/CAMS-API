namespace CAMS_API.Models.DTO.AuthenticationDTO
{
    public class AuthenticationResponseModel
    {
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
