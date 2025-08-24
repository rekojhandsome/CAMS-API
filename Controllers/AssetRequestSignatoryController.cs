using AutoMapper;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Runtime.InteropServices;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetRequestSignatoryController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;

        public AssetRequestSignatoryController(IUnitOfWork uow, IMapper mapper, IAccountRepository accountRepository)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetRequestSignatoryModel>>> GetAssetRequestSignatories()
        {
            var assetRequestSignatories = await uow.AssetRequestSignatories.GetAssetRequestSignatoriesAsync();

            var assetRequestSignatoryModels = mapper.Map<IEnumerable<AssetRequestSignatoryModel>>(assetRequestSignatories);

            return Ok(assetRequestSignatoryModels);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AssetRequestSignatoryModel>> CreateAssetRequestSignatory([FromBody] AssetRequestSignatoryModel model)
        {
            var assetRequestSignatory = mapper.Map<AssetRequestSignatoryModel, AssetRequestSignatory>(model);

            await uow.AssetRequestSignatories.CreateAssetRequestSignatory(assetRequestSignatory);
            await uow.CompleteAsync();

            var assetRequestSignatoryModel = mapper.Map<AssetRequestSignatoryModel>(assetRequestSignatory);

            return Ok(assetRequestSignatoryModel);
        }

        [Authorize]
        [HttpGet("signatories")]
        public async Task<ActionResult<IEnumerable<AssetRequestHeaderResponseModel>>> GetSignatoriesByAssetRequest()
        {
            //var signatoryID = await accountRepository.GetAccountIDAsync();

            var loginIDClaim = User.FindFirst("loginID")?.Value;

            if (string.IsNullOrEmpty(loginIDClaim) || !int.TryParse(loginIDClaim, out int accountID))
            {
                return Unauthorized(new { message = "Invalid Token or user not authenticated" });
            }

            var signatory = await uow.Employees.GetEmployeeProfile(accountID);

            var signatories = await uow.AssetRequestSignatories.GetSignatoriesForPendingAssetRequest(signatory.EmployeeID, signatory.DepartmentID);

            var signatoriesModel = mapper.Map<IEnumerable<AssetRequestHeaderResponseModel>>(signatories);

            return Ok(signatoriesModel);

        }

    }
}
