using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetRequestHeaderModel>>> GetAssetRequestHeaders()
        {
            var assetRequestHeaders = await uow.AssetRequestHeaders.GetAssetRequestHeadersAsync();

            var assetRequestHeaderModels = mapper.Map<IEnumerable<AssetRequestHeader>, IEnumerable<AssetRequestHeaderModel>>(assetRequestHeaders);

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
        public async Task<ActionResult<AssetRequestHeaderModel>> CreateAssetRequestHeader([FromBody] AssetRequestHeaderModel model)
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

            int sequenceID = 1;

            var assetRequestHeader = mapper.Map<AssetRequestHeader>(model);
            assetRequestHeader.EmployeeID = employee.EmployeeID;

            foreach (var item in assetRequestHeader.AssetRequestDetails)
            {
                item.SequenceID = sequenceID;
            }

            await uow.AssetRequestHeaders.CreateAssetRequestHeaderAsync(assetRequestHeader);
            await uow.CompleteAsync();

            var assetRequestHeaderModel = mapper.Map<AssetRequestHeaderResponseModel>(assetRequestHeader);

            return Ok(assetRequestHeaderModel);


            ////CASE 1: ARH id exists, increment sequenceID
            //if (model.AssetRequestID.HasValue && model.AssetRequestID > 0)
            //{
            //    var existingAssetRequestHeader = await uow.AssetRequestHeaders.GetAssetRequestHeaderIDAsync((int)model.AssetRequestID);
            //    if (existingAssetRequestHeader == null)
            //    {
            //        return NotFound($"Asset Request Header with ID {model.AssetRequestID} is not found.");
            //    }

            //    var maxSequenceID = await uow.AssetRequestDetails.FindMaxSequenceIDAsync((int)model.AssetRequestID);

            //    foreach (var detail in model.AssetRequestDetails)
            //    {
            //        var newDetail = mapper.Map<AssetRequestDetail>(detail);
            //        newDetail.AssetRequestID = (int)model.AssetRequestID;
            //        newDetail.SequenceID = ++maxSequenceID;
            //        existingAssetRequestHeader.AssetRequestDetails.Add(newDetail);
            //    }

            //    await uow.CompleteAsync();
            //    var updatedAssetRequestHeaderModel = mapper.Map<AssetRequestHeader, AssetRequestHeaderResponseModel>(existingAssetRequestHeader);
            //    return Ok(updatedAssetRequestHeaderModel);
            //}

            ////CASE 2: ARH id does not exist, create new ARH
            //var newAssetRequestHeader = mapper.Map<AssetRequestHeader>(model);
            //newAssetRequestHeader.EmployeeID = employee.EmployeeID;

            //int sequenceID = 1;
            //foreach (var detail in newAssetRequestHeader.AssetRequestDetails)
            //{
            //    detail.SequenceID = sequenceID++;
            //}

            //await uow.AssetRequestHeaders.CreateAssetRequestHeaderAsync(newAssetRequestHeader);
            //await uow.CompleteAsync();

            ////var assetRequestHeader = mapper.Map<AssetRequestHeader>(model);
            ////assetRequestHeader.EmployeeID = employee.EmployeeID;


            ////await uow.AssetRequestHeaders.CreateAssetRequestHeaderAsync(assetRequestHeader);
            ////await uow.CompleteAsync();

            //var assetRequestHeaderModel = mapper.Map<AssetRequestHeaderResponseModel>(newAssetRequestHeader);

            //return Ok();
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

            return Ok("Asset request deleted successfully.");
        }
    }
}
