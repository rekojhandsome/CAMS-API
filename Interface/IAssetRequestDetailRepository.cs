using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IAssetRequestDetailRepository
    {
        Task<AssetRequestDetail> CreateAssetRequestDetailAsync(AssetRequestDetail assetRequestDetail);
        Task<int> FindMaxSequenceIDAsync(int assetRequestID);
        Task<Decimal> GetTotalAssetValueAsync(int assetRequestHeaderID);
    }
}
