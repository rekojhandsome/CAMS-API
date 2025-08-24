using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Models.DTO.AssetRequestHeaderDTO
{
    public class AssetRequestHeaderResponseModel
    {
        public DateTime AssetRequestDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PositionName { get; set; }
        public string? DepartmentName { get; set; }
        public string? Status { get; set; }
        public int TotalAssetValue { get; set; }
        public bool RequiresApproval { get; set; }

        public ICollection<AssetRequestDetailResponseModel> AssetRequestDetails { get; set; } = new List<AssetRequestDetailResponseModel>();
        public ICollection<AssetRequestSignatoryModel> AssetRequestSignatories { get; set; } = new List<AssetRequestSignatoryModel>();

        public AssetRequestHeaderResponseModel()
        {
            AssetRequestDetails = new List<AssetRequestDetailResponseModel>();
            AssetRequestSignatories = new List<AssetRequestSignatoryModel>();
        }
    }
}
