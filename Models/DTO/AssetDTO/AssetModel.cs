namespace CAMS_API.Models.DTO.AssetDTO
{
    public class AssetModel
    {
        public int DeviceID { get; set; }
        public required string AssetName { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime DateAcquired { get; set; }
        public int Price { get; set; }
        public required string Status { get; set; }
    }
}
