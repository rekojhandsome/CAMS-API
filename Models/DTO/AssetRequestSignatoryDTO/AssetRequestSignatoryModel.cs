namespace CAMS_API.Models.DTO.AssetRequestSignatoryDTO
{
    public class AssetRequestSignatoryModel
    {
        public int AssetRequestID { get; set; }
        public int SequenceID { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public int PositionID { get; set; }
        public string? PositionName { get; set; }
        public int SignatoryID { get; set; }
        public string? SignatoryName { get; set; }
        public int Level { get; set; }
        public bool IsSigned { get; set; }
    }
}
