using AutoMapper;
using CAMS_API.Models.DTO.DepartmentDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentModel>();
            CreateMap<DepartmentModel, Department>();
        }
    }
}
