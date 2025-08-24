namespace CAMS_API.Models.Entities
{
    public class Device
    {
        public int DeviceID { get; set; }
        public required string DeviceName { get; set; }
        public required string DeviceType { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
