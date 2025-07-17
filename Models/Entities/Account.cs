namespace CAMS_API.Models.Entities
{
    public class Account
    {
        public int AccountID { get; set; }
        public required string Username { get; set; } = string.Empty;
        public required string Passwrod { get; set; } = string.Empty;
    }
}
