using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Models.DTO.AssetRequestHeaderDTO
{
    public class AssetRequestHeaderModel
    {
        public DateTime assetRequestDate { get; set; } = DateTime.UtcNow;
    }
}
