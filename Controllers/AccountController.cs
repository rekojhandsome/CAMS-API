using AutoMapper;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AccountController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("Accounts")]
        public async Task<ActionResult<IEnumerable<AccountModel>>> GetAccounts()
        {
            var accounts = await uow.Accounts.GetAccountsAsync();

            var accountModels = mapper.Map<IEnumerable<AccountModel>>(accounts);

            return Ok(accountModels);
        }
    }
}
