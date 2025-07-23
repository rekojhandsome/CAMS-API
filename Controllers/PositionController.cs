using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.PositionDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PositionController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionModel>>> GetPositions()
        {
            var positions = await uow.Positions.GetPositionsAsync();

            var positionModels = mapper.Map<IEnumerable<Position>, IEnumerable<PositionModel>>(positions);

            return Ok(positionModels);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PositionModel>> GetPosition(int id)
        {
            var findPosition = await uow.Positions.GetPositionByIDAsync(id);
            if (findPosition == null)
            {
                return NotFound($"Position with ID {id} is not found.");
            }
            var positionModel = mapper.Map<Position, PositionModel>(findPosition);
            return Ok(positionModel);
        }

        [HttpPost]
        public async Task<ActionResult<PositionModel>> CreatePosition([FromBody] PositionModel model)
        {
            var position = mapper.Map<PositionModel, Position>(model);
            await uow.Positions.CreatePositionAsync(position);

            await uow.CompleteAsync();

            return CreatedAtAction(nameof(GetPosition), new { id = position.PositionID }, model);

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PositionModel>> UpdatePosition([FromBody] PositionModel model, int id)
        {
            var existingPosition = await uow.Positions.GetPositionByIDAsync(id);
            if (existingPosition == null)
            {
                return NotFound($"Position with ID {id} is not found.");
            }

            mapper.Map(model, existingPosition);
            await uow.CompleteAsync();

            var updatedPosition = mapper.Map<Position, PositionModel>(existingPosition);
            return Ok(updatedPosition);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PositionModel>> DeletePosition(int id)
        {
            var positionToDelete = await uow.Positions.GetPositionByIDAsync(id);
            if (positionToDelete == null)
            {
                return NotFound($"Position with ID {id} is not found.");
            }

            uow.Positions.DeletePosition(positionToDelete);
            await uow.CompleteAsync();

            return Ok("Position deleted successfully.");

        }
    }
}
