using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.EmployeeDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
            var employees = await uow.Employees.GetEmployeesAsync();

            var employeeModels = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeModel>>(employees);

            return Ok(employeeModels);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployee(int id)
        {
            var findEmployee = await uow.Employees.GetEmployeeByIDAsync(id);

            if (findEmployee == null)
            {
                return NotFound($"Employee with ID {id} is not found.");
            }

            var employeeModel = mapper.Map<Employee, EmployeeModel>(findEmployee);
            return Ok(employeeModel);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> CreateEmployee([FromBody] EmployeeModel model)
        {
            var employee = mapper.Map<EmployeeModel, Employee>(model);

            await uow.Employees.CreateEmployeeAsync(employee);
            await uow.CompleteAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeID }, model); 
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeModel>> UpdateEmployee([FromBody] EmployeeModel model, int id)
        {
            var existingEmployee = await uow.Employees.GetEmployeeByIDAsync(id);

            if (existingEmployee == null)
            {
                return NotFound($"Employee with ID {id} is not found.");
            }

            var employee = mapper.Map<EmployeeModel, Employee>(model);
            await uow.CompleteAsync();

            var updatedEmployee = mapper.Map<Employee, EmployeeModel>(employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employeeToDelete = await uow.Employees.GetEmployeeByIDAsync(id);
            if (employeeToDelete == null)
            {
                return NotFound($"Employee with ID {id} is not found.");
            }

            uow.Employees.DeleteEmployee(employeeToDelete);
            await uow.CompleteAsync();

            return Ok("Employee deleted successfully.");
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeProfile()
        {
            var loginID = User.FindFirst("LoginID")?.Value;

            if (loginID == null || !int.TryParse(loginID, out int accountID))
            {
                return Unauthorized(new { message = "Invalid Token or user not authenticated." });
            }

            var employee = await uow.Employees.GetEmployeeProfile(accountID);

            if (employee == null)
            {
                return NotFound(new {message = "Employee not found."});
            }

            var employeeModel = mapper.Map<EmployeeModel>(employee);

            return Ok(employeeModel);

        }

    }
}
