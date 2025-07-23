using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PositionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Position> CreatePositionAsync(Position position)
        {
            await dbContext.Positions.AddAsync(position);
            return position;
        }

        public void DeletePosition(Position position)
        {
            dbContext.Positions.Remove(position);
        }

        public async Task<Position> GetPositionByIDAsync(int id)
        {
            return await dbContext.Positions.FirstOrDefaultAsync(p => p.PositionID == id);
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await dbContext.Positions.ToListAsync();
        }
    }
}
