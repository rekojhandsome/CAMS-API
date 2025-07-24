using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Account> FindAccountByUsername(string username)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task<Account> GetAccountByID(int accountID)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(a => a.AccountID == accountID);
        }

        public Task<string> LoginAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> RegisterAsync(Account account)
        {
            await dbContext.Accounts.AddAsync(account);
            return account;
        }

        
    }
}
