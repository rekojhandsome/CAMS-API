using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetRequestDetailController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AssetRequestDetailController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpPost("details")]
        public async Task<ActionResult<AssetRequestDetailModel>> CreateAssetRequestDetail([FromBody] AssetRequestDetailModel model)
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

            var header = await uow.AssetRequestHeaders.GetAssetRequestHeaderByEmployeeAsync(employee.EmployeeID);
            if (header == null)
            {
                return NotFound("Request header by employee not found");
            }

            var price = await uow.Assets.FindAssetPrice(model.assetID);
            if (price == null)
            {
                return NotFound($"Asset with ID {model.assetID} not found.");
            }

            var maxSequenceID = await uow.AssetRequestDetails.FindMaxSequenceIDAsync(header.AssetRequestID);

            int sequenceID = ((int?)maxSequenceID ?? 0) + 1;


            var detail = new AssetRequestDetail
            {
                AssetRequestID = header.AssetRequestID,
                SequenceID = sequenceID,
                AssetID = model.assetID,
                Price = price.Value
            };

            await uow.AssetRequestDetails.CreateAssetRequestDetailAsync(detail);
            await uow.CompleteAsync();

            //Calculate the TotalAssetValue
            var totalValue = await uow.AssetRequestDetails.GetTotalAssetValueAsync(header.AssetRequestID);
            header.TotalAssetValue = totalValue;
            await uow.CompleteAsync();

            var assetRequestDetailModel = mapper.Map<AssetRequestDetailResponseModel>(detail);
            return Ok(assetRequestDetailModel);
        }
    }
}
