namespace CAMS_API.Models.DTO.AssetDTO
{
    public class AssetModel
    {
        public int deviceID { get; set; }
        public required string assetTag { get; set; }
        public required string serialNumber { get; set; }
        public DateTime dateAcquired { get; set; }
        public int price { get; set; }
        public required string status { get; set; }
    }
}
