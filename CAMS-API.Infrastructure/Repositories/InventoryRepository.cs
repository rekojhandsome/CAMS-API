using CAMS_API.CAMS_API.Core.Entities;
using CAMS_API.CAMS_API.Core.Interfaces;
using CAMS_API.Data;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.CAMS_API.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public InventoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Inventory> GetInventoryByAssetIDAsync(int assetID)
        {
            return await dbContext.Inventories
        .Where(i => i.AssetID == assetID)
        .FirstOrDefaultAsync();
        }

        public void UpdateInventoryQuantityAsync(Inventory inventory)
        {
            //var inventoryItem = await GetInventoryByAssetIDAsync(assetID);

            //if (inventoryItem is null)
            //    return null;

            //if (inventoryItem.Quantity < quantityToDeduct)
            //    return null;

            //inventoryItem.Quantity = inventoryItem.Quantity - quantityToDeduct;

            //dbContext.Inventories.Update(inventoryItem);

            //return inventoryItem;

            dbContext.Inventories.Update(inventory);
        }
    }
}
