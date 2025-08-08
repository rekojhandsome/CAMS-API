using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IAssetRequestSignatory
    {
        Task<IEnumerable<AssetRequestSignatory>> GetAssetRequestSignatoriesAsync();
        Task<AssetRequestSignatory> CreateAssetRequestSignatory(AssetRequestSignatory signatory);
    }
}
