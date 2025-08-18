using CAMS_API.Interfaces.Service_Interfaces;

namespace CAMS_API.Interface.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IAssetRepository Assets { get; }
        IAssetRequestDetailRepository AssetRequestDetails { get; }
        IAssetRequestHeaderRepository AssetRequestHeaders { get; }
        IAssetRequestSignatoryRepository AssetRequestSignatories { get; }
        IDepartmentRepository Departments { get; }
        IDeviceRepository Devices { get; }
        IDocumentSignatoryRepository DocumentSignatories { get; }
        IEmployeeRepository Employees { get; }
        IPositionRepository Positions { get; }

        //Services
        IAuthenticationServiceRepository AuthenticationService { get; }
        IAssetRequestHeaderServiceRepository AssetRequestHeaderService { get; }

        Task<int> CompleteAsync();
    }
}
