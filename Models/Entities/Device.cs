namespace CAMS_API.Models.Entities
{
    public class Device
    {
        public int deviceID { get; set; }
        public string deviceName { get; set; }
        public string deviceType { get; set; }
        public string brand { get; set; }
        public string model { get; set; }

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
