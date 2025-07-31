using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAssetsAsync();
        Task<Asset> GetAssetByIDAsync(int id);
        Task<Asset> CreateAssetAsync(Asset asset);
        Task<Asset> UpdateAssetAsync(Asset asset);
        Task<int?> FindAssetPrice(int assetID);
        void DeleteAsset(Asset asset);
    }
}
