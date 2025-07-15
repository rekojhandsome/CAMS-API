using AutoMapper;
using CAMS_API.Models.DTO.EmployeeDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
        }
    }
}
