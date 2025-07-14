using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AssetRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Asset> CreateAssetAsync(Asset asset)
        {
            await dbContext.Assets.AddAsync(asset);
            return asset;
        }

        public void DeleteAsset(Asset asset)
        {
            dbContext.Assets.Remove(asset);
        }

        public async Task<Asset> GetAssetByIDAsync(int id)
        {
            return await dbContext.Assets.FirstOrDefaultAsync(a => a.assetID == id);
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync()
        {
            return await dbContext.Assets.ToListAsync();
        }

        public Task<Asset> UpdateAssetAsync(Asset asset)
        {
            throw new NotImplementedException();
        }
    }
}
