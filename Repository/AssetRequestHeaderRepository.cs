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

        public async Task<AssetRequestHeader> GetAssetRequestHeaderIDAsync(int employeeID)
        {
            //var id = await dbContext.AssetRequestHeaders.MaxAsync(arh => (int?)arh.AssetRequestID);
            // return new AssetRequestHeader
            // {
            //     AssetRequestID = id.GetValueOrDefault() + 1,
            //     AssetRequestDate = DateTime.UtcNow,
            //     EmployeeID = 0,
            //     Status = "Pending",
            //     TotalAssetValue = 0,
            //     RequiresApproval = false,
            //     AssetRequestDetails = { }


            // };

            return await dbContext.AssetRequestHeaders.FirstOrDefaultAsync(arh => arh.EmployeeID == employeeID);
        }

        public async Task<IEnumerable<AssetRequestHeader>> GetAssetRequestHeadersAsync()
        {
            return await dbContext.AssetRequestHeaders
                .Include(arh => arh.AssetRequestDetails)
                .ToListAsync();
        }
    }
}
