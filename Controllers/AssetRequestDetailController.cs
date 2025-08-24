using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;

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
        public async Task<ActionResult<IEnumerable<AssetRequestDetailResponseModel>>> CreateAssetRequestDetail([FromBody] object requestBody) // keep as object for flexibility
        {
            // To be converted to a service method
            var loginID = User.FindFirst("loginID")?.Value;

            if (loginID == null || !int.TryParse(loginID, out int accountID))
                return Unauthorized("Invalid token or user not authenticated.");

            // To be converted to a service method
            var employee = await uow.Employees.GetEmployeeProfile(accountID);
            if (employee == null)
                return NotFound("Employee not found.");

            // To be converted to a service method
            var header = await uow.AssetRequestHeaders.GetAssetRequestHeaderByEmployeeAsync(employee.EmployeeID);
            if (header == null)
                return NotFound("Request header by employee not found");

            // ✅ Properly deserialize into DTO list
            var details = new List<AssetRequestDetailModel>();

            var json = requestBody.ToString();
            if (string.IsNullOrWhiteSpace(json))
                return BadRequest("Request body cannot be empty.");

            if (json.TrimStart().StartsWith("["))
            {
                details = JsonSerializer.Deserialize<List<AssetRequestDetailModel>>(json);
            }
            else if (json.TrimStart().StartsWith("{"))
            {
                var singleDetail = JsonSerializer.Deserialize<AssetRequestDetailModel>(json);
                if (singleDetail != null)
                    details.Add(singleDetail);
            }
            else
            {
                return BadRequest("Invalid request body format. Must be an object or array.");
            }

            if (details == null || !details.Any())
                return BadRequest("No valid asset details provided.");

            var createdDetails = new List<AssetRequestDetail>();


            var maxSequenceID = await uow.AssetRequestDetails.FindMaxSequenceIDAsync(header.AssetRequestID);
            int sequenceID = (int?)maxSequenceID ?? 0;

            // Process each detail
            foreach (var model in details)
            {
                var price = await uow.Assets.FindAssetPrice(model.assetID);
                if (price == null)
                    return NotFound($"Asset with ID {model.assetID} not found.");

                sequenceID++;

                var assetDetail = new AssetRequestDetail
                {
                    AssetRequestID = header.AssetRequestID,
                    SequenceID = sequenceID,
                    AssetID = model.assetID,
                    Price = price.Value
                };

                await uow.AssetRequestDetails.CreateAssetRequestDetailAsync(assetDetail);
                createdDetails.Add(assetDetail);
            }

            await uow.CompleteAsync();

            var totalValue = await uow.AssetRequestDetails.GetTotalAssetValueAsync(header.AssetRequestID);
            header.TotalAssetValue = totalValue;

            int valueThreshold = 5000;

            if (totalValue > valueThreshold)
            {
                header.RequiresApproval = true;

                var existingSignatories = await uow.AssetRequestSignatories.GetSignatoryByRequestIDAsync(header.AssetRequestID);

                if (!existingSignatories.Any())
                {
                    var department = await uow.Departments.GetDepartmentByEmployeeAsync(employee.EmployeeID);
                    if (department == null)
                        return NotFound("Department not found for employee.");

                    var documents = await uow.DocumentSignatories.GetDocumentSignatoryAsync(employee.DepartmentID);

                    header.AssetRequestSignatories = documents.Select((doc, index) => new AssetRequestSignatory
                    {
                        AssetRequestID = header.AssetRequestID,
                        SequenceID = index + 1,
                        DepartmentID = doc.DepartmentID,
                        DepartmentName = department.DepartmentName ?? string.Empty,
                        PositionID = doc.PositionID,
                        SignatoryID = doc.SignatoryID,
                        SignatoryName = doc.SignatoryName ?? string.Empty,
                        PositionName = doc.PositionName ?? string.Empty,
                        Level = doc.Level,
                    }).ToList();
                }
            }

            await uow.CompleteAsync();

            var assetRequestDetailModel = mapper.Map<IEnumerable<AssetRequestDetailResponseModel>>(createdDetails);
            return Ok(assetRequestDetailModel);
        }

    }
}
