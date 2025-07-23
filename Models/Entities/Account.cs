namespace CAMS_API.Models.Entities
{
    public class Account
    {
        public int AccountID { get; set; }
        public  string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }
    }
}
