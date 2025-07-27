namespace CAMS_API.Models.DTO.AccountDTO
{
    public class AccountModel
    {
        public required string Username { get; set; } = string.Empty;
        public required string Role { get; set; } = string.Empty;
        public int EmployeeID { get; set; }

    }
}
