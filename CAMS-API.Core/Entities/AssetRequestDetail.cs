namespace CAMS_API.Models.Entities
{
    public class AssetRequestDetail
    {
        public int AssetRequestID { get; set; }
        public int SequenceID { get; set; }
        public int AssetID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public AssetRequestHeader? AssetRequestHeader { get; set; }
        public Asset? Asset { get; set; }
    }
}
