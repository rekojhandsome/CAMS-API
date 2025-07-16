using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.Entities;
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

        [HttpPost]
        public async Task<ActionResult<AssetRequestHeaderModel>> CreateAssetRequestHeader([FromBody] AssetRequestHeaderModel model)
        {
            var assetRequestHeader = mapper.Map<AssetRequestHeaderModel, AssetRequestHeader>(model);

            await uow.AssetRequestHeaders.CreateAssetRequestHeaderAsync(assetRequestHeader);
            await uow.CompleteAsync();

            return CreatedAtAction(nameof(GetAssetRequestHeader), new { id = assetRequestHeader.assetRequestID }, model);
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
