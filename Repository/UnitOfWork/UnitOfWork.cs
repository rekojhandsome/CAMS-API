using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;

namespace CAMS_API.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        
        public IAccountRepository Accounts { get; private set; }
        public IAssetRepository Assets { get; private set; }

        public IAssetRequestHeaderRepository AssetRequestHeaders { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public IDeviceRepository Devices { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public IPositionRepository Positions { get; private set; }

        

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

            Accounts = new AccountRepository(dbContext);
            Assets = new AssetRepository(dbContext);
            AssetRequestHeaders = new AssetRequestHeaderRepository(dbContext);
            Departments = new DepartmentRepository(dbContext);
            Devices = new DeviceRepository(dbContext);
            Employees = new EmployeeRepository(dbContext);
            Positions = new PositionRepository(dbContext);
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
