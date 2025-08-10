using CAMS_API.Models.Entities;
namespace CAMS_API.Interface
{
    public interface IAssetRequestSignatoryRepository
    {
        Task<IEnumerable<AssetRequestSignatory>> GetAssetRequestSignatoriesAsync();
        Task<AssetRequestSignatory> CreateAssetRequestSignatory(AssetRequestSignatory signatory);
        Task<IEnumerable<AssetRequestSignatory>> GetSignatoryByRequestID(int assetRequestID);
    }
}
