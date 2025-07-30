using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IAssetRequestDetailRepository
    {
        Task<int> FindMaxSequenceIDAsync(int assetRequestID);
    }
}
