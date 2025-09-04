using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Interfaces.Service_Interfaces
{
    public interface IAssetRequestHeaderServiceRepository
    {
        Task<ServiceResultDTO<AssetRequestHeaderModel>> CreateAssetRequestHeaderAsync(AssetRequestHeaderModel model);
        Task<string> PatchAssetRequestHeader();
    }
}
