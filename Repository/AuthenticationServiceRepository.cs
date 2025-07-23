using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AuthenticationDTO;
using CAMS_API.Models.Entities;
using CAMS_API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CAMS_API.Repository
{
    public class AuthenticationServiceRepository : IAuthenticationServiceRepository
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public AuthenticationServiceRepository(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }
        public async Task<AuthenticationResponseModel?> LoginAsync(Account account)
        {
            var user = await uow.Accounts.FindAccountByUsername(account.Username);
            if (user == null)
            {
                return null;
            }

            if (new PasswordHasher<Account>().VerifyHashedPassword(user, user.Password, account.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return await CreateTokenResponse(user);
        }

        private async Task<AuthenticationResponseModel> CreateTokenResponse(Account account)
        {
            return new AuthenticationResponseModel
            {
                Username = account.Username,
                Token = CreateToken(account),
            };
        }

        public async Task<Account> RegisterAsync(AccountRegisterModel model)
        {
            var existingUsername = await uow.Accounts.FindAccountByUsername(model.Username);

            if(existingUsername != null)
            {
                return null; // Username already exists
            }

            var user = new Account();

            var hashedPassword = new PasswordHasher<Account>()
                .HashPassword(user, model.Password);

            user.Username = model.Username;
            user.Password = hashedPassword;
            user.Role = model.Role;
            user.EmployeeID = model.EmployeeID;

            await uow.Accounts.RegisterAsync(user);
            await uow.CompleteAsync();

            return user;

        }

        private string CreateToken(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.NameIdentifier, account.AccountID.ToString())

            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        
    }
}
