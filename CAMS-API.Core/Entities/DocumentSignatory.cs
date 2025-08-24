namespace CAMS_API.Models.Entities
{
    public class DocumentSignatory
    {
        public int DocumentID { get; set; }
        public int DepartmentID { get; set; } 
        public int SignatoryID { get; set; }
        public string? DocumentName { get; set; }
        public string? SignatoryName { get; set; }
        public int PositionID { get; set; }
        public string? PositionName { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
        public DateTime  DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
