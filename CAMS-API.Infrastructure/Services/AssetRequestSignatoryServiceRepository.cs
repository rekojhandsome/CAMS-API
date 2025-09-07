using CAMS_API.CAMS_API.Core.Interfaces.Service_Interfaces;
using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;

namespace CAMS_API.CAMS_API.Infrastructure.Services
{
    public class AssetRequestSignatoryServiceRepository : IAssetRequestSignatoryServiceRepository
    {
        public Task<ServiceResultDTO<AssetRequestSignatoryModel>> PatchSignatoriesAsync(AssetRequestSignatoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
