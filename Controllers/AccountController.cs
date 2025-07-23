using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AccountDTO;
using CAMS_API.Models.DTO.AuthenticationDTO;
using CAMS_API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IAuthenticationServiceRepository authService;

        public AccountController(IUnitOfWork uow, IMapper mapper, IAuthenticationServiceRepository authService)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AccountRegisterModel>> Register([FromBody] AccountRegisterModel model)
        {
            
            var registeredAccount = await authService.RegisterAsync(model);
            if (registeredAccount == null)
            {
                return BadRequest("Username already exists.");
            }
            
            var createdAccount = mapper.Map<AccountModel>(registeredAccount);

            return Ok(createdAccount);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginModel>> Login([FromBody] LoginModel model)
        {

            var login = await authService.LoginAsync(model);
            if (login == null)
            {
                return BadRequest("Invalid username or password.");
            }

            return Ok(login);
        }

        [Authorize]
        [HttpGet("authenticated-user-only")]
        public IActionResult AuthenticatedUserEndpoint()
        {
            return Ok("You are authenticated!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-endpoint-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are an Admin!");
        }
    }
}
