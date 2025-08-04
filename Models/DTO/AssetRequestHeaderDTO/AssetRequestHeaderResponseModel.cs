using CAMS_API.Models.DTO.AssetRequestDetailDTO;

namespace CAMS_API.Models.DTO.AssetRequestHeaderDTO
{
    public class AssetRequestHeaderResponseModel
    {
        public DateTime AssetRequestDate { get; set; } = DateTime.UtcNow;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PositionName { get; set; }
        public string? DepartmentName { get; set; }
        public string? Status { get; set; }
        public int TotalAssetValue { get; set; }
        public bool RequiresApproval { get; set; }

        public ICollection<AssetRequestDetailResponseModel> AssetRequestDetails { get; set; } = new List<AssetRequestDetailResponseModel>();

        public AssetRequestHeaderResponseModel()
        {
            AssetRequestDetails = new List<AssetRequestDetailResponseModel>();
        }
    }
}
