using CAMS_API.Models.Entities;

namespace CAMS_API.Service
{
    public interface IAuthenticationServiceRepository
    {
        Task<Account> RegisterAsync(Account account);
        Task<Account> LoginAsync(Account account);
    }
}
