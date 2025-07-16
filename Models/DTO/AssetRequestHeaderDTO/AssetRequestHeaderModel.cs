using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Models.DTO.AssetRequestHeaderDTO
{
    public class AssetRequestHeaderModel
    {
        public DateTime assetRequestDate { get; set; } = DateTime.UtcNow;
        public int employeeID { get; set; }
        public string? status { get; set; }
        public decimal totalAssetValue { get; set; }
        public bool requiresApproval { get; set; }

        public ICollection<AssetRequestDetailModel> AssetRequestDetails { get; set; } = new List<AssetRequestDetailModel>();

        public AssetRequestHeaderModel()
        {
            AssetRequestDetails = new List<AssetRequestDetailModel>();
        }
    }
}
