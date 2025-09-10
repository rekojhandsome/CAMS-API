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

        public void UpdateInventoryQuantity(Inventory inventory)
        {
            dbContext.Entry(inventory).State = EntityState.Modified;
        }
    }
}
