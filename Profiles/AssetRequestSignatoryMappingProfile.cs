using AutoMapper;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class AssetRequestSignatoryMappingProfile : Profile
    {
        public AssetRequestSignatoryMappingProfile()
        {
            CreateMap<AssetRequestSignatory, AssetRequestSignatoryModel>();
            CreateMap<AssetRequestSignatoryModel, AssetRequestSignatory>();
        }
    }
}
