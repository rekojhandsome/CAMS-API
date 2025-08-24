namespace CAMS_API.Models.Entities
{
    public class Position
    {
        public int PositionID { get; set; }
        public required string PositionName { get; set; }

        //Navigation Properties
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
