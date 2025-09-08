using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;

namespace CAMS_API.CAMS_API.Core.Interfaces.Service_Interfaces
{
    public interface IAssetRequestSignatoryServiceRepository
    {
        Task<ServiceResultDTO<AssetRequestSignatoryModel>> PatchPendingRequestAsync(AssetRequestSignatoryModel model);
    }
}
