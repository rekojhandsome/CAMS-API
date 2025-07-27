using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IAccountRepository
    {
        Task<Account> FindAccountByUsername(string username);
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByID(int accountID);
        Task<Account> RegisterAsync(Account account);

    }
}
