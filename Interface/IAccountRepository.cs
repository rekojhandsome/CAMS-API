using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IAccountRepository
    {
        Task<Account> FindAccountByUsername(string username);
        Task<Account> RegisterAsync(Account account);
        Task<string> LoginAsync(Account account);
        Task<Account> GetAccountByID(int accountID);
    }
}
