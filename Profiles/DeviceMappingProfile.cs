using AutoMapper;
using CAMS_API.Models.DTO.DeviceDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Profiles
{
    public class DeviceMappingProfile : Profile
    {
        public DeviceMappingProfile()
        {
            CreateMap<Device, DeviceModel>();
            CreateMap<DeviceModel, Device>();
        }
    }
}
