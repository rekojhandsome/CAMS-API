using AutoMapper;
using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class AssetRequestDetailMappingProfile : Profile
    {
        public AssetRequestDetailMappingProfile()
        {
            CreateMap<AssetRequestDetail, AssetRequestDetailModel>();
            CreateMap<AssetRequestDetailModel, AssetRequestDetail>();
        }
    }
}
