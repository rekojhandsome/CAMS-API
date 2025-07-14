namespace CAMS_API.Models.Entities
{
    public class Asset
    {
        public int assetID { get; set; }
        public int deviceID { get; set; }
        public required string assetTag { get; set; }
        public required string serialNumber { get; set; }
        public DateTime dateAcquired { get; set; }
        public int price { get; set; }
        public required string status { get; set; }

        public required Device Device { get; set; }
        public ICollection<AssetRequestDetail> AssetRequestDetails { get; set; } = new List<AssetRequestDetail>();
    }
}
