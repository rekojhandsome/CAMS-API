using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AccountDTO;
using CAMS_API.Models.DTO.AuthenticationDTO;
using CAMS_API.Models.Entities;
using CAMS_API.Service;
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
        public async Task<ActionResult<AuthenticationModel>> Register(AuthenticationModel model)
        {
            var account = mapper.Map<Account>(model);
            if (account == null)
            {
                return BadRequest("Username already exists.");
            }

            var registeredAccount = await authService.RegisterAsync(account);
            var registeredAccountModel = mapper.Map<AccountModel>(registeredAccount);

            return Ok(registeredAccountModel);
        }
    }
}
