using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AssetController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetModel>>> GetAssets()
        {
            var assets = await uow.Assets.GetAssetsAsync();
            var assetModels = mapper.Map<IEnumerable<Asset>, IEnumerable<AssetModel>>(assets);
            return Ok(assetModels);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AssetModel>> GetAsset(int id)
        {
            var findAsset = await uow.Assets.GetAssetByIDAsync(id);
            if (findAsset == null)
            {
                return NotFound($"Asset with ID {id} is not found.");
            }
            var assetModel = mapper.Map<Asset, AssetModel>(findAsset);

            return Ok(assetModel);
        }

        [HttpPost]
        public async Task<ActionResult<AssetModel>> CreateAsset([FromBody] AssetModel model)
        {
            var asset = mapper.Map<AssetModel, Asset>(model);

            await uow.Assets.CreateAssetAsync(asset);
            await uow.CompleteAsync();

            return CreatedAtAction(nameof(GetAsset), new { id = asset.AssetID }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AssetModel>> UpdateAsset([FromBody] AssetModel model, int id)
        {
            var existingAsset = await uow.Assets.GetAssetByIDAsync(id);

            if (existingAsset == null)
            {
                return NotFound($"Asset with ID {id} is not found.");
            }

            mapper.Map(model, existingAsset);
            await uow.CompleteAsync();

            var updateAsset = mapper.Map<Asset, AssetModel>(existingAsset);
            return Ok(updateAsset);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsset(int id)
        {
            var assetToDelete = await uow.Assets.GetAssetByIDAsync(id);
            if (assetToDelete == null)
            {
              return NotFound($"Asset with ID {id} is not found.");
            }
            uow.Assets.DeleteAsset(assetToDelete);
            await uow.CompleteAsync();

            return Ok("Asset deleted successfully.");
        }

    }
}
