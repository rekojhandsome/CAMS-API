namespace CAMS_API.Interface.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IAssetRepository Assets { get; }
        IAssetRequestHeaderRepository AssetRequestHeaders { get; }
        IDepartmentRepository Departments { get; }
        IDeviceRepository Devices { get; }
        IEmployeeRepository Employees { get; }
        IPositionRepository Positions { get; }

        Task<int> CompleteAsync();
    }
}
