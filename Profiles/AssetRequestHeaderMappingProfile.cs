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
            CreateMap<AssetRequestHeader, AssetRequestHeaderModel>().ReverseMap();

            CreateMap<AssetRequestHeader, AssetRequestHeaderResponseModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.FirstName : null))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.LastName : null))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Employee.Position != null ? src.Employee.Position.PositionName : null))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Employee.Department != null ? src.Employee.Department.DepartmentName : null));

        }
    }
}
