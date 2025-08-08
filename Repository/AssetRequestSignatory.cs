using CAMS_API.Data;
using CAMS_API.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AssetRequestSignatory : IAssetRequestSignatory
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
    }
}
