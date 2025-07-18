using CAMS_API.Models.Entities;
using CAMS_API.Service;

namespace CAMS_API.Repository
{
    public class AuthenticationServiceRepository : IAuthenticationServiceRepository
    {
        public Task<Account> LoginAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> RegisterAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
