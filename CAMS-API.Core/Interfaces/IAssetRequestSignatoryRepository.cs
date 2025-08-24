using CAMS_API.Models.Entities;
namespace CAMS_API.Interface
{
    public interface IAssetRequestSignatoryRepository
    {
        Task<IEnumerable<AssetRequestSignatory>> GetAssetRequestSignatoriesAsync();
        Task<AssetRequestSignatory> CreateAssetRequestSignatoryAsync(AssetRequestSignatory signatory);
        Task<IEnumerable<AssetRequestSignatory>> GetSignatoryByRequestIDAsync(int assetRequestID);
        Task<IEnumerable<AssetRequestHeader>> GetSignatoriesForPendingAssetRequestAsync(int signatoryID, int departmentID);
        Task<AssetRequestHeader> GetAssetRequestWithSignatoriesAsync(int assetRequestID);
    }
}
