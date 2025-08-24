namespace CAMS_API.Models.DTO.AuthenticationDTO
{
    public class RefreshTokenRequestModel
    {
        public int AccountID { get; set; }
        public required string RefreshToken { get; set; }
    }
}
