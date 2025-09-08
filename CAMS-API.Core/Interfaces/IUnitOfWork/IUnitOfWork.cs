using CAMS_API.CAMS_API.Core.Interfaces;
using CAMS_API.CAMS_API.Core.Interfaces.Service_Interfaces;
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
        IInventoryRepository Inventories { get; }
        IPositionRepository Positions { get; }

        //Services
        IAuthenticationServiceRepository AuthenticationService { get; }
        IAssetRequestHeaderServiceRepository AssetRequestHeaderService { get; }
        IAssetRequestDetailServiceRepository AssetRequestDetailService { get; }
        IAssetRequestSignatoryServiceRepository AssetRequestSignatoryService { get; }

        Task<int> CompleteAsync();
    }
}
