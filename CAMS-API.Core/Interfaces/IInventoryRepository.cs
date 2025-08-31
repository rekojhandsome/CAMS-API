using CAMS_API.CAMS_API.Core.Entities;

namespace CAMS_API.CAMS_API.Core.Interfaces
{
    public interface IInventoryRepository
    {
         Task<Inventory> GetInventoryByAssetIDAsync(int assetID);
         void UpdateInventoryQuantityAsync(Inventory inventory);
    }
}
