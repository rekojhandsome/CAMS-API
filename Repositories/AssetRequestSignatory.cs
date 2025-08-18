using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AssetRequestSignatory : IAssetRequestSignatoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AssetRequestSignatory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Models.Entities.AssetRequestSignatory> CreateAssetRequestSignatory(Models.Entities.AssetRequestSignatory signatory)
        {
            await dbContext.AssetRequestSignatories.AddAsync(signatory);
            return signatory;
        }

        public async Task<IEnumerable<Models.Entities.AssetRequestSignatory>> GetAssetRequestSignatoriesAsync()
        {
            return await dbContext.AssetRequestSignatories.ToListAsync();
        }

        public async Task<IEnumerable<Models.Entities.AssetRequestSignatory>> GetSignatoryByRequestID(int assetRequestID)
        {
            return await dbContext.AssetRequestSignatories
                .Where(ars => ars.AssetRequestID == assetRequestID)
                .ToListAsync();
        }
    }
}
