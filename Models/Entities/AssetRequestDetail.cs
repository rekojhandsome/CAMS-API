namespace CAMS_API.Models.Entities
{
    public class AssetRequestDetail
    {
        public int AssetRequestID { get; set; }
        public int SequenceID { get; set; }
        public int AssetID { get; set; }
        public decimal AssetValue { get; set; }

        public AssetRequestHeader? AssetRequestHeader { get; set; }
    }
}
