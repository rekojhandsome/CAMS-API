using AutoMapper;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class AssetRequestHeaderMappingProfile : Profile
    {
        public AssetRequestHeaderMappingProfile()
        {
            CreateMap<AssetRequestHeaderModel, AssetRequestHeader>();
            CreateMap<AssetRequestHeader, AssetRequestHeaderModel>();
        }
    }
}
