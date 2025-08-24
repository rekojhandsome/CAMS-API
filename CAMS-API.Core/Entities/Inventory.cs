using CAMS_API.Models.Entities;

namespace CAMS_API.CAMS_API.Core.Entities
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int AssetID { get; set; }
        public int Quantity { get; set; }

        public Asset? Asset { get; set; }

    }
}
