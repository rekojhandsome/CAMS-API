using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.DeviceDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public DeviceController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceModel>>> GetDevices()
        {
            var devices = await uow.Devices.GetDevicesAsync();
            var deviceModels = mapper.Map<IEnumerable<Device>,IEnumerable<DeviceModel>>(devices);
            return Ok(deviceModels);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DeviceModel>> GetDevice(int id)
        {
            var findDevice = await uow.Devices.GetDeviceByIDAsync(id);

            if (findDevice == null)
            {
                return NotFound($"Device with ID {id} is not found.");
            }
            var deviceModel = mapper.Map<Device, DeviceModel>(findDevice);
            return Ok(deviceModel);
        }

        [HttpPost]
        public async Task<ActionResult<DeviceModel>> CreateDevice([FromBody] DeviceModel model)
        {
            var device = mapper.Map<DeviceModel, Device>(model);

            await uow.Devices.CreateDeviceAsync(device);
            await uow.CompleteAsync();

            return CreatedAtAction(nameof(GetDevice), new { id = device.deviceID }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DeviceModel>> UpdateDevice(DeviceModel model, int id)
        {
            var existingDevice = await uow.Devices.GetDeviceByIDAsync(id);

            if (existingDevice == null)
            {
                return NotFound($"Device with ID {id} is not found.");
            }

            mapper.Map(model, existingDevice);

            await uow.CompleteAsync();

            var updatedDevice = mapper.Map<Device, DeviceModel>(existingDevice);
            return Ok(updatedDevice);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            var deviceToDelete = await uow.Devices.GetDeviceByIDAsync(id);
            if (deviceToDelete == null)
            {
                return NotFound($"Device with ID {id} is not found.");
            }

            uow.Devices.DeleteDevice(deviceToDelete);
            await uow.CompleteAsync();

            return Ok("Device deleted successfully.");
        }
    }
}
