using AutoMapper;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Interfaces.Service_Interfaces;
using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CAMS_API.Services
{
    public class AssetRequestHeaderServiceRepository : IAssetRequestHeaderServiceRepository
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;

        public AssetRequestHeaderServiceRepository(IUnitOfWork uow, IMapper mapper, IAccountRepository accountRepository)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }
        public async Task<ServiceResultDTO<AssetRequestHeaderModel>> CreateAssetRequestHeaderAsync(AssetRequestHeaderModel model)
        {
            var accountID = await accountRepository.GetAccountIDAsync();
            
            var employee = await ValidateEmployeeAsync(accountID);

            var existingRequestHeader = await GetExistingRequestHeaderAsync(employee.EmployeeID);
            if (existingRequestHeader != null)
            {
                var failedModel = mapper.Map<AssetRequestHeaderModel>(existingRequestHeader);

                return ServiceResultDTO<AssetRequestHeaderModel>
                    .Fail("Employee already has an active asset request header", failedModel);
            }

            var header = await CreateNewHeaderAsync(model, employee.EmployeeID);

            var result = mapper.Map<AssetRequestHeaderModel>(header);

            return ServiceResultDTO<AssetRequestHeaderModel>.Ok("Request successful!",result);
        }

        private async Task<Employee> ValidateEmployeeAsync(int accountID)
        {
            var employee = await uow.Employees.GetEmployeeProfile(accountID);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found.");

            return employee;
        }

        private async Task<AssetRequestHeader?> GetExistingRequestHeaderAsync(int employeeID)
        {
            return await uow.AssetRequestHeaders.GetAssetRequestHeaderWithoutDetailAsync(employeeID);
        }

        private async Task<AssetRequestHeader> CreateNewHeaderAsync(AssetRequestHeaderModel model, int employeeID)
        {
            var header = mapper.Map<AssetRequestHeader>(model);
            header.EmployeeID = employeeID;
            header.Status = "Draft";
            header.AssetRequestDate = DateTime.UtcNow;

            await uow.AssetRequestHeaders.CreateAssetRequestHeaderAsync(header);
            await uow.CompleteAsync();

            return header;
        }

    }
}
