using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IPosititionRepository
    {
        Task<IEnumerable<Position>> GetPositionsAsync();
        Task<Position> GetPositionByIDAsync(int id);
        Task<Position> CreatePositionAsync(Position position);
        void DeletePosition(Position position);
    }
}
