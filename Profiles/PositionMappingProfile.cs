using AutoMapper;
using CAMS_API.Models.DTO.PositionDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class PositionMappingProfile : Profile
    {
        public PositionMappingProfile()
        {
            CreateMap<Position, PositionModel>();
            CreateMap<PositionModel, Position>();
        }
    }
}
