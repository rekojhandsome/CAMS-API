using CAMS_API.Service;

namespace CAMS_API.Interface.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IAssetRepository Assets { get; }
        IAssetRequestDetailRepository AssetRequestDetails { get; }
        IAssetRequestHeaderRepository AssetRequestHeaders { get; }
        IAuthenticationServiceRepository AuthenticationService { get; }
        IDepartmentRepository Departments { get; }
        IDeviceRepository Devices { get; }
        IEmployeeRepository Employees { get; }
        IPositionRepository Positions { get; }

        Task<int> CompleteAsync();
    }
}
