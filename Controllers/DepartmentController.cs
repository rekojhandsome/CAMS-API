using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.DepartmentDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public DepartmentController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
        {
            var departments = await uow.Departments.GetDepartmentsAsync();

            var departmentModels = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentModel>>(departments);

            return Ok(departmentModels);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartment(int id)
        {
            var findDepartment = await uow.Departments.GetDepartmentByIDAsync(id);

            if (findDepartment == null)
            {
                return NotFound($"Department with ID {id} is not found.");
            }

            var departmentModel = mapper.Map<Department, DepartmentModel>(findDepartment);
            return Ok(departmentModel);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> CreateDepartment([FromBody] DepartmentModel model)
        {
            var department = mapper.Map<DepartmentModel, Department>(model);

            await uow.Departments.CreateDepartmentAsync(department);
            await uow.CompleteAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = department.departmentID }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DepartmentModel>> UpdateDepartment([FromBody] DepartmentModel model, int id)
        {
            var existingDepartment = await uow.Departments.GetDepartmentByIDAsync(id);
            if (existingDepartment == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            mapper.Map(model, existingDepartment);
            await uow.CompleteAsync();

            var updatedDepartment = mapper.Map<Department, DepartmentModel>(existingDepartment);
            return Ok(updatedDepartment);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DepartmentModel>> DeleteDepartment(int id)
        {
            var departmentToDelete = await uow.Departments.GetDepartmentByIDAsync(id);
            if (departmentToDelete == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            uow.Departments.DeleteDepartment(departmentToDelete);
            await uow.CompleteAsync();

            return Ok("Department deleted successfully.");
        }
    }
}
