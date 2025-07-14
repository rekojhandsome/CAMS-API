namespace CAMS_API.Models.Entities
{
    public class AssetRequestDetail
    {
        public int assetRequestID { get; set; }
        public int sequenceID { get; set; }
        public int assetID { get; set; }
        public decimal assetValue { get; set; }

        public AssetRequestHeader? AssetRequestHeader { get; set; }
    }
}
