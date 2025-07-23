using CAMS_API.Models.DTO.AccountDTO;
using CAMS_API.Models.DTO.AuthenticationDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Service
{
    public interface IAuthenticationServiceRepository
    {
        Task<Account> RegisterAsync(AccountRegisterModel account);
        Task<AuthenticationResponseModel> LoginAsync(LoginModel model);
    }
}
