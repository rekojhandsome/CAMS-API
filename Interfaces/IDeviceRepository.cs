using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetDevicesAsync();
        Task<Device> GetDeviceByIDAsync(int id);
        Task<Device> CreateDeviceAsync(Device device);
        void DeleteDevice(Device device);
    }
}
