namespace CAMS_API.Models.DTO.AuthenticationDTO
{
    public class TokenResponseModel
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
