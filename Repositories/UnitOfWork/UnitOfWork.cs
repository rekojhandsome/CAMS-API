using AutoMapper;
using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Interfaces.Service_Interfaces;
using CAMS_API.Services;

namespace CAMS_API.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public IAccountRepository Accounts { get; private set; }
        public IAssetRepository Assets { get; private set; }

        public IAssetRequestHeaderRepository AssetRequestHeaders { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public IDeviceRepository Devices { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public IPositionRepository Positions { get; private set; }

        public IAuthenticationServiceRepository AuthenticationService { get; private set; }

        public IAssetRequestDetailRepository AssetRequestDetails { get; private set; }

        public IAssetRequestSignatoryRepository AssetRequestSignatories { get; private set; }

        public IDocumentSignatoryRepository DocumentSignatories { get; private set; }

        public IAssetRequestHeaderServiceRepository AssetRequestHeaderService { get; private set; }


        public UnitOfWork(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            this.configuration = configuration;

            Accounts = new AccountRepository(dbContext, httpContextAccessor);
            Assets = new AssetRepository(dbContext);
            AssetRequestHeaders = new AssetRequestHeaderRepository(dbContext);
            AssetRequestDetails = new AssetRequestDetailRepository(dbContext);
            AssetRequestSignatories = new AssetRequestSignatory(dbContext);
            Departments = new DepartmentRepository(dbContext);
            Devices = new DeviceRepository(dbContext);
            DocumentSignatories = new DocumentSignatoryRepository(dbContext);
            Employees = new EmployeeRepository(dbContext);
            Positions = new PositionRepository(dbContext);

            //Services
            AuthenticationService = new AuthenticationServiceRepository(this, configuration, mapper);
            AssetRequestHeaderService = new AssetRequestHeaderServiceRepository(this, mapper, Accounts);
            
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
