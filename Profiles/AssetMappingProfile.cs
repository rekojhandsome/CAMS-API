using AutoMapper;
using CAMS_API.Models.DTO.AssetDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class AssetMappingProfile : Profile
    {
        public AssetMappingProfile()
        {
            CreateMap<Asset, AssetModel>();
            CreateMap<AssetModel, Asset>();
        }
    }
}
