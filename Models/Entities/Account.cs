namespace CAMS_API.Models.Entities
{
    public class Account
    {
        public int AccountID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public required string Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public int EmployeeID { get; set; }
        public required Employee Employee { get; set; }
    }
}
