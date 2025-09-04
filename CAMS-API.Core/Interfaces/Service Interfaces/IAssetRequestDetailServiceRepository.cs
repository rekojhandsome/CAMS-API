using CAMS_API.Models.DTO.AssetRequestDetailDTO;

namespace CAMS_API.Interface
{
    public interface IAssetRequestDetailServiceRepository
    {
        Task<AssetRequestDetailModel> CreateAssetRequestDetailAsync(object requestBody);
    }
}
