using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetRequestSignatoryController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AssetRequestSignatoryController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
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
        
    }
}
