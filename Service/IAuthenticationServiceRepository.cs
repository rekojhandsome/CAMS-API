using CAMS_API.Models.DTO.AuthenticationDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Service
{
    public interface IAuthenticationServiceRepository
    {
        Task<Account> RegisterAsync(Account account);
        Task<AuthenticationResponseModel> LoginAsync(Account account);
    }
}
