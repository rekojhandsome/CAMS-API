using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Interfaces.Service_Interfaces
{
    public interface IAssetRequestHeaderServiceRepository
    {
        Task<ServiceResultDTO<AssetRequestHeaderModel>> CreateAssetRequestHeaderAsync(AssetRequestHeaderModel model);
    }
}
