using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AssetRequestDetailRepository : IAssetRequestDetailRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AssetRequestDetailRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AssetRequestDetail> CreateAssetRequestDetailAsync(AssetRequestDetail assetRequestDetail)
        {
            await dbContext.AddAsync(assetRequestDetail);
            return assetRequestDetail;
        }

        public async Task<int> FindMaxSequenceIDAsync(int assetRequestID)
        {
            return await dbContext.AssetRequestDetails
                .Where(ard => ard.AssetRequestID == assetRequestID)
                .MaxAsync(ard => (int?)ard.SequenceID) ?? 0;
        }

        public async Task<decimal> GetTotalAssetValueAsync(int assetRequestHeaderID)
        {
            var total = await dbContext.AssetRequestDetails
                .Where(ard => ard.AssetRequestID == assetRequestHeaderID)
                .SumAsync(ard => ard.Price);

            return total;
        }
    }
}
