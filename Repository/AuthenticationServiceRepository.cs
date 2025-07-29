using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AccountDTO;
using CAMS_API.Models.DTO.AuthenticationDTO;
using CAMS_API.Models.Entities;
using CAMS_API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CAMS_API.Repository
{
    public class AuthenticationServiceRepository : IAuthenticationServiceRepository
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthenticationServiceRepository(IUnitOfWork uow, IConfiguration configuration, IMapper mapper)
        {
            this.uow = uow;
            this.configuration = configuration;
            this.mapper = mapper;
        }
        public async Task<TokenResponseModel?> LoginAsync(LoginModel model)
        {
            var user = await uow.Accounts.FindAccountByUsername(model.Username);
            if (user == null)
            {
                return null;
            }

            if (new PasswordHasher<Account>().VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            TokenResponseModel response = await CreateTokenResponse(user);

            return response;
        }

        private async Task<TokenResponseModel> CreateTokenResponse(Account user)
        {
            return new TokenResponseModel
            {
                Username = user.Username,
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshToken(user),
                RefreshTokenExpiryTime = user.RefreshTokenExpiryTime
            };
        }

        public async Task<Account> RegisterAccountAsync(RegisterModel model)
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

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
        public async Task<TokenResponseModel?> RefreshTokenAsync(RefreshTokenRequestModel model)
        {
            var user = await ValidateRefreshTokenAsync(model.AccountID, model.RefreshToken);
            if (user == null)
            {
                return null;
            }

            return await CreateTokenResponse(user);

        }
        private async Task<Account?> ValidateRefreshTokenAsync(int accountID, string refreshToken)
        {
            var user = await uow.Accounts.GetAccountByID(accountID);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null; // Invalid or expired refresh token
            }

            return user;
        }

        private async Task<string> GenerateAndSaveRefreshToken(Account Account)
        {
            var refreshToken = GenerateRefreshToken();

            Account.RefreshToken = refreshToken;
            Account.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await uow.CompleteAsync();

            return refreshToken;
        }

        private string CreateToken(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.NameIdentifier, account.AccountID.ToString()),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("loginID", account.AccountID.ToString()),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        
    }
}
