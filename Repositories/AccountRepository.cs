using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Account> FindAccountByUsername(string username)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task<Account> GetAccountByID(int accountID)
        {
            return await dbContext.Accounts.FirstOrDefaultAsync(a => a.AccountID == accountID);
        }
        public Task<int> GetAccountIDAsync()
        {
            var loginID = httpContextAccessor.HttpContext?.User.FindFirst("loginID")?.Value;
            if (loginID == null || !int.TryParse(loginID, out int accountID))
                throw new UnauthorizedAccessException("Invalid token or user not authenticated.");

            return Task.FromResult(accountID);
        }
        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await dbContext.Accounts.ToListAsync();
        }

        public async Task<Account> RegisterAsync(Account account)
        {
            await dbContext.Accounts.AddAsync(account);
            return account;
        }
    }
}
