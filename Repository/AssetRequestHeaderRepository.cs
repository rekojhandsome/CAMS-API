using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AssetRequestHeaderRepository : IAssetRequestHeaderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AssetRequestHeaderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AssetRequestHeader> CreateAssetRequestHeaderAsync(AssetRequestHeader assetRequestHeader)
        {
            await dbContext.AssetRequestHeaders.AddAsync(assetRequestHeader);
            return assetRequestHeader;
        }

        public void DeleteAssetRequestHeader(AssetRequestHeader assetRequestHeader)
        {
            dbContext.AssetRequestHeaders.Remove(assetRequestHeader);
        }

        public async Task<AssetRequestHeader> GetAssetRequestHeaderByIDAsync(int id)
        {
            return await dbContext.AssetRequestHeaders.FirstOrDefaultAsync(arh => arh.AssetRequestID == id);
        }

        public async Task<AssetRequestHeader> GetAssetRequestHeaderByEmployeeAsync(int employeeID)
        {
            return await dbContext.AssetRequestHeaders
                .Where(arh => arh.EmployeeID == employeeID && arh.Status == "Draft")
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AssetRequestHeader>> GetAssetRequestHeadersAsync()
        {
            return await dbContext.AssetRequestHeaders
                .Include(arh => arh.AssetRequestDetails)
                .ToListAsync();
        }
    }
}
