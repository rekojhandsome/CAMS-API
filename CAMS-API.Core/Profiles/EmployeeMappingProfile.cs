using AutoMapper;
using CAMS_API.Models.DTO.EmployeeDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeResponseModel>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position != null ? src.Position.PositionName : null));
            CreateMap<EmployeeResponseModel, Employee>();

            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
        }
    }
}
