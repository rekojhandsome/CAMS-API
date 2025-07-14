namespace CAMS_API.Models.Entities
{
    public class Position
    {
        public int positionID { get; set; }
        public required string positionName { get; set; }

        //Navigation Properties
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
