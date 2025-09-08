using AutoMapper;
using CAMS_API.CAMS_API.Core.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
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

            CreateMap<PatchAssetRequestSignatoryModel, AssetRequestSignatoryModel>();
            CreateMap<AssetRequestSignatoryModel, PatchAssetRequestSignatoryModel>();

        }
    }
}
