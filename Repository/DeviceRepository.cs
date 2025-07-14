using CAMS_API.Data;
using CAMS_API.Interface;
using CAMS_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAMS_API.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DeviceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Device> CreateDeviceAsync(Device device)
        {
            await dbContext.Devices.AddAsync(device);
            return device;
        }

        public void DeleteDevice(Device device)
        {
            dbContext.Devices.Remove(device);
        }

        public async Task<Device> GetDeviceByIDAsync(int id)
        {
            return await dbContext.Devices.FirstOrDefaultAsync(d => d.deviceID == id);
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            return await dbContext.Devices.ToListAsync();
        }
    }
}
