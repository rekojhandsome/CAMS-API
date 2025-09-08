using AutoMapper;
using CAMS_API.CAMS_API.Core.DTO.AssetRequestSignatoryDTO;
using CAMS_API.CAMS_API.Core.Interfaces.Service_Interfaces;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IAssetRequestSignatoryServiceRepository assetRequestSignatoryServiceRepository;
        private readonly IAccountRepository accountRepository;

        public AssetRequestSignatoryController(IUnitOfWork uow, IMapper mapper, IAssetRequestSignatoryServiceRepository assetRequestSignatoryServiceRepository, IAccountRepository accountRepository)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.assetRequestSignatoryServiceRepository = assetRequestSignatoryServiceRepository;
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

            await uow.AssetRequestSignatories.CreateAssetRequestSignatoryAsync(assetRequestSignatory);
            await uow.CompleteAsync();

            var assetRequestSignatoryModel = mapper.Map<AssetRequestSignatoryModel>(assetRequestSignatory);

            return Ok(assetRequestSignatoryModel);
        }

        [Authorize]
        [HttpGet("signatories")]
        public async Task<ActionResult<IEnumerable<AssetRequestHeaderResponseModel>>> GetSignatoriesByAssetRequest()
        {
            var signatoryID = await accountRepository.GetAccountIDAsync();

            var signatory = await uow.Employees.GetEmployeeProfile(signatoryID);

            var signatories = await uow.AssetRequestSignatories.GetSignatoriesForPendingAssetRequestAsync(signatory.EmployeeID, signatory.DepartmentID);

            var signatoriesModel = mapper.Map<IEnumerable<AssetRequestHeaderResponseModel>>(signatories);

            return Ok(signatoriesModel);
        }

        [Authorize]
        [HttpPatch]
        public async Task<ActionResult> PatchSignatoriesByAssetRequest([FromBody] PatchAssetRequestSignatoryModel model)
        {
            var mappedModel = mapper.Map<PatchAssetRequestSignatoryModel, AssetRequestSignatoryModel>(model);
            var result = await assetRequestSignatoryServiceRepository.PatchPendingRequestAsync(mappedModel);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


    }
}
