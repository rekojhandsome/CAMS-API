namespace CAMS_API.Models.Entities
{
    public class AssetRequestHeader
    {
        public int assetRequestID { get; set; }
        public DateTime assetRequestDate { get; set; } = DateTime.UtcNow;
        public int employeeID { get; set; }
        public string? status { get; set; }
        public decimal totalAssetValue { get; set; }
        public bool requiresApproval { get; set; }

        public Employee? Employee { get; set; }
        public ICollection<AssetRequestDetail> AssetRequestDetails { get; set; } = new List<AssetRequestDetail>();

        public AssetRequestHeader()
        {
            AssetRequestDetails = new List<AssetRequestDetail>();
        }
    }
}
