using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IAssetRequestHeaderRepository
    {
        Task<IEnumerable<AssetRequestHeader>> GetAssetRequestHeadersAsync();
        Task<AssetRequestHeader> GetAssetRequestHeaderByIDAsync(int id);
        Task<AssetRequestHeader> CreateAssetRequestHeaderAsync(AssetRequestHeader assetRequestHeader);
        void DeleteAssetRequestHeader(AssetRequestHeader assetRequestHeader);
    }
}
