using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.PortableExecutable;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetRequestHeaderController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AssetRequestHeaderController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetRequestHeaderResponseModel>>> GetAssetRequestHeaders()
        {
            var assetRequestHeaders = await uow.AssetRequestHeaders.GetAssetRequestHeadersAsync();

            var assetRequestHeaderModels = mapper.Map<IEnumerable<AssetRequestHeaderResponseModel>>(assetRequestHeaders);

            return Ok(assetRequestHeaderModels);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AssetRequestHeaderModel>> GetAssetRequestHeader(int id)
        {
            var findAssetRequestHeader = await uow.AssetRequestHeaders.GetAssetRequestHeaderByIDAsync(id);
            if (findAssetRequestHeader == null)
            {
                return NotFound($"Asset Request Header with ID {id} is not found.");
            }

            var assetRequestHeaderModel = mapper.Map<AssetRequestHeader, AssetRequestHeaderModel>(findAssetRequestHeader);
            return Ok(assetRequestHeaderModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> CreateAssetRequestHeader([FromBody] AssetRequestHeaderModel model)
        {
            var loginID = User.FindFirst("loginID")?.Value;

            if (loginID == null || !int.TryParse(loginID, out int accountID))
            {
                return Unauthorized("Invalid token or user not authenticated.");
            }

            var employee = await uow.Employees.GetEmployeeProfile(accountID);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            var assetRequestHeader = mapper.Map<AssetRequestHeader>(model);
            assetRequestHeader.EmployeeID = employee.EmployeeID;
            assetRequestHeader.Status = "Draft";

            await uow.AssetRequestHeaders.CreateAssetRequestHeaderAsync(assetRequestHeader);
            await uow.CompleteAsync();

            return Ok(assetRequestHeader.AssetRequestID);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AssetRequestHeaderModel>> UpdateAssetRequestHeader([FromBody] AssetRequestHeaderModel model, int id)
        {
            var existingAssetRequestHeader = await uow.AssetRequestHeaders.GetAssetRequestHeaderByIDAsync(id);

            if (existingAssetRequestHeader == null)
            {
                return NotFound($"Asset Request Header with ID {id} is not found.");
            }

            var assetRequestHeader = mapper.Map(model, existingAssetRequestHeader);
            await uow.CompleteAsync();

            var updatedAssetRequestHeaderModel = mapper.Map<AssetRequestHeader, AssetRequestHeaderModel>(assetRequestHeader);
            return Ok(updatedAssetRequestHeaderModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AssetRequestHeaderModel>> DeleteAssetRequestHeader(int id)
        {
            var assetRequestHeaderToDelete = await uow.AssetRequestHeaders.GetAssetRequestHeaderByIDAsync(id);

            if (assetRequestHeaderToDelete == null)
            {
                return NotFound($"Asset Request Header with ID {id} is not found.");
            }

            uow.AssetRequestHeaders.DeleteAssetRequestHeader(assetRequestHeaderToDelete);
            await uow.CompleteAsync();

            return Ok("Asset request deleted successfully.");
        }

        [Authorize]
        [HttpPatch]
        public async Task<ActionResult> PatchAssetRequestHeader([FromBody] PatchAssetRequestHeaderModel model)
        {
            var loginID = User.FindFirst("loginID")?.Value;

            if (string.IsNullOrEmpty(loginID) || !int.TryParse(loginID, out int accountID))
            {
                return Unauthorized("Invalid token or user not authenticated.");
            }

            var employee = await uow.Employees.GetEmployeeProfile(accountID);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            var header = await uow.AssetRequestHeaders.GetAssetRequestHeaderByEmployeeAsync(employee.EmployeeID);
            if (header == null)
            {
                return NotFound("Request header by employee not found.");
            }

            header.Status = "Pending";

            await uow.CompleteAsync();

            return NoContent();
        }
    }
}
