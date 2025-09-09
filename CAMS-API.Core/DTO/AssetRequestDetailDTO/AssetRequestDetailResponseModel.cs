namespace CAMS_API.Models.DTO.AssetRequestDetailDTO
{
    public class AssetRequestDetailResponseModel
    {
        public int assetRequestID { get; set; }
        public int sequenceID { get; set; }
        public int assetID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
