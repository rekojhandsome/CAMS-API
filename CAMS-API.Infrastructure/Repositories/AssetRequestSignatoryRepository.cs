using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class AssetRequestSignatoryRepository : IAssetRequestSignatoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AssetRequestSignatoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AssetRequestSignatory> CreateAssetRequestSignatory(Models.Entities.AssetRequestSignatory signatory)
        {
            await dbContext.AssetRequestSignatories.AddAsync(signatory);
            return signatory;
        }

        public async Task<IEnumerable<AssetRequestHeader>> GetSignatoriesForPendingAssetRequest(int signatoryID, int departmentID)
        {
            return await dbContext.AssetRequestHeaders
                .Include(arh => arh.AssetRequestDetails)
                .Include(arh => arh.AssetRequestSignatories)
                .Include(arh => arh.Employee)
                .Where(arh => arh.AssetRequestSignatories.Any(s =>
                    s.SignatoryID == signatoryID && 
                    s.DepartmentID == departmentID 
                    && s.IsSigned == null &&
                !arh.AssetRequestSignatories.Any(prev => prev.Level < s.Level && prev.IsSigned != true)))
                .ToListAsync();
        }
       

        //public async Task<IEnumerable<AssetRequestHeader>> GetSignatoriesForPendingAssetRequest(int signatoryID, int departmentID)
        //{
        //    return await dbContext.AssetRequestHeaders
        //        .Include(arh => arh.AssetRequestDetails)
        //        .Include(arh => arh.AssetRequestSignatories)
        //        .Include(arh => arh.Employee)
        //        .Where(arh => arh.AssetRequestSignatories.Any(s =>
        //            s.SignatoryID == signatoryID &&
        //            s.DepartmentID == departmentID &&
        //            s.IsSigned == null &&
        //            // ✅ all lower-level signatories must be approved (true), not null or false
        //            arh.AssetRequestSignatories
        //                .Where(prev => prev.Level < s.Level)
        //                .All(prev => prev.IsSigned == true)))
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<AssetRequestSignatory>> GetAssetRequestSignatoriesAsync()
        {
            return await dbContext.AssetRequestSignatories.ToListAsync();
        }

        public async Task<IEnumerable<AssetRequestSignatory>> GetSignatoryByRequestID(int assetRequestID)
        {
            return await dbContext.AssetRequestSignatories
                .Where(ars => ars.AssetRequestID == assetRequestID)
                .ToListAsync();
        }
    }
}
