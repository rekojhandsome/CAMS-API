using AutoMapper;
using CAMS_API.Models.DTO.AccountDTO;
using CAMS_API.Models.DTO.AuthenticationDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            // Mapping between Account and AccountModel
            CreateMap<Account, AccountModel>();
            CreateMap<AccountModel, Account>();

            // Mapping between AuthenticationModel and Account
            CreateMap<AccountRegisterModel, Account>();
            CreateMap<Account, AccountRegisterModel>();

            //Mapping between LoginModel and Account
            CreateMap<LoginModel, Account>();
            CreateMap<Account, LoginModel>();

            //Mapping between AuthenticationResponseModel and Account
            CreateMap<AuthenticationResponseModel, Account>();
            CreateMap<Account, AuthenticationResponseModel>();

            //Mapping between TokenResponseModel and AuthenticationResponseModel
            CreateMap<TokenResponseModel, AuthenticationResponseModel>();
            CreateMap<AuthenticationResponseModel, TokenResponseModel>();
        }
    }
}
