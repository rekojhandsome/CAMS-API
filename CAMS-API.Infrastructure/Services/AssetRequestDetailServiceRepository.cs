using AutoMapper;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.Entities;
using System.Text.Json;

namespace CAMS_API.CAMS_API.Infrastructure.Services
{
    public class AssetRequestDetailServiceRepository(IUnitOfWork uow, IMapper mapper, IAccountRepository accountRepository) : IAssetRequestDetailServiceRepository
    {
        private readonly IUnitOfWork uow = uow;
        private readonly IMapper mapper = mapper;
        private readonly IAccountRepository accountRepository = accountRepository;

        public async Task<ServiceResultDTO<IEnumerable<AssetRequestDetailResponseModel>>> CreateAssetRequestDetailAsync(object requestBody)
        {
            //Get AccountID from Token
            var accountID = await accountRepository.GetAccountIDAsync();

            //Validate Employee based on Token
            var employee = await ValidateEmployeeAsync(accountID);
            if (employee is null)
                return ServiceResultDTO<IEnumerable<AssetRequestDetailResponseModel>>.Fail("Employee not found.");

            //Get asset request header
            var header = await uow.AssetRequestHeaders.GetAssetRequestHeaderByEmployeeAsync(employee.EmployeeID);
            if (header is null)
                return ServiceResultDTO<IEnumerable<AssetRequestDetailResponseModel>>.Fail("Request header by employee not found.");

            //Deserialize request body into detail models
            var details = DeserializeRequestBody(requestBody);
            if (details is null || !details.Any())
                return ServiceResultDTO<IEnumerable<AssetRequestDetailResponseModel>>.Fail("No valid asset details provided.");

            var createdDetails = new List<AssetRequestDetail>();

            //Get latest sequenceID
            var maxSequenceID = await uow.AssetRequestDetails.FindMaxSequenceIDAsync(header.AssetRequestID);
            int sequenceID = (int?)maxSequenceID ?? 0;

            //Process each detail
            foreach (var model in details)
            {
                var price = await uow.Assets.FindAssetPrice(model.AssetID);
                if (price is null)
                    return ServiceResultDTO<IEnumerable<AssetRequestDetailResponseModel>>.Fail($"Asset with ID {model.AssetID} not found.");

                sequenceID++;

                var assetDetail = new AssetRequestDetail
                {
                    AssetRequestID = header.AssetRequestID,
                    SequenceID = sequenceID,
                    AssetID = model.AssetID,
                    Price = price.Value,
                    Quantity = model.Quantity
                };

                await uow.AssetRequestDetails.CreateAssetRequestDetailAsync(assetDetail);
                createdDetails.Add(assetDetail);
               
            }

            //Save changes
            await uow.CompleteAsync();

            // Update header total
            var totalValue = await uow.AssetRequestDetails.GetTotalAssetValueAsync(header.AssetRequestID);
            header.TotalAssetValue = totalValue;

            // Handle signatories if threshold exceeded
            await HandleSignatoriesAsync(header, employee, totalValue);

            // save again after header/signatories updates
            await uow.CompleteAsync();

            var response = mapper.Map<IEnumerable<AssetRequestDetailResponseModel>>(createdDetails);
            return ServiceResultDTO<IEnumerable<AssetRequestDetailResponseModel>>.Ok("Asset details updated successfully.", response);
        }
        private async Task<Employee?> ValidateEmployeeAsync(int accountID)
        {
            return await uow.Employees.GetEmployeeByIDAsync(accountID);
        }

        private List<AssetRequestDetailModel?>? DeserializeRequestBody(object requestBody)
        {
            var json = requestBody.ToString();
            if (string.IsNullOrEmpty(json)) return null;

            if (json.TrimStart().StartsWith("[")) {
                var details = JsonSerializer.Deserialize<List<AssetRequestDetailModel?>>(json);
                return details;
            }
            if (json.TrimStart().StartsWith("{"))
            {
                var detail = JsonSerializer.Deserialize<AssetRequestDetailModel?>(json);
                return detail != null ? new List<AssetRequestDetailModel?> { detail } : null;
            }

            return null;
        }

        private async Task HandleSignatoriesAsync(AssetRequestHeader header, Employee employee, decimal totalValue)
        {
            int valueThreshold = 5000;
            if (totalValue <= valueThreshold) return;

            header.RequiresApproval = true;

            var existingSignatories = await uow.AssetRequestSignatories.GetSignatoryByRequestIDAsync(header.AssetRequestID);
            if (existingSignatories.Any()) return;

            var department = await uow.Departments.GetDepartmentByEmployeeAsync(employee.EmployeeID);
            if (department is null)
                throw new KeyNotFoundException("Department not found for employee.");

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
}
