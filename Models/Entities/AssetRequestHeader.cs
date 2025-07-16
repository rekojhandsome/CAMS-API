namespace CAMS_API.Models.Entities
{
    public class AssetRequestHeader
    {
        public int AssetRequestID { get; set; }
        public DateTime AssetRequestDate { get; set; } = DateTime.UtcNow;
        public int EmployeeID { get; set; }
        public string? Status { get; set; }
        public decimal TotalAssetValue { get; set; }
        public bool RequiresApproval { get; set; }

        public Employee? Employee { get; set; }
        public ICollection<AssetRequestDetail> AssetRequestDetails { get; set; } = new List<AssetRequestDetail>();

        public AssetRequestHeader()
        {
            AssetRequestDetails = new List<AssetRequestDetail>();
        }
    }
}
