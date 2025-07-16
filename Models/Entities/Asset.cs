namespace CAMS_API.Models.Entities
{
    public class Asset
    {
        public int AssetID { get; set; }
        public int DeviceID { get; set; }
        public required string AssetName { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime DateAcquired { get; set; }
        public int Price { get; set; }
        public required string Status { get; set; }

        public required Device Device { get; set; }
        public ICollection<AssetRequestDetail> AssetRequestDetails { get; set; } = new List<AssetRequestDetail>();
    }
}
