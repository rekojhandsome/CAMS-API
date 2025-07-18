using CAMS_API.Data;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.Entities;
using CAMS_API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AuthenticationServiceRepository : IAuthenticationServiceRepository
    {
        private readonly IUnitOfWork uow;

        public AuthenticationServiceRepository(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public Task<Account> LoginAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> RegisterAsync(Account account)
        {
            var existingUsername = await uow.Accounts.FindAccountByUsername(account.Username);

            if(existingUsername != null)
            {
                return null; // Username already exists
            }

            var user = new Account{
                Username = account.Username,
                Password = "",
                Role = account.Role,
            };

            user.Password = new PasswordHasher<Account>()
                 .HashPassword(user, account.Password);

            await uow.Accounts.RegisterAsync(user);
            await uow.CompleteAsync();

            return user;

        }
    }
}
