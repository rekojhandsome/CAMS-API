using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestDetailDTO;

namespace CAMS_API.Interface
{
    public interface IAssetRequestDetailServiceRepository
    {
        Task<ServiceResultDTO<IEnumerable<AssetRequestDetailResponseModel>>> CreateAssetRequestDetailAsync(object requestBody);
    }
}
