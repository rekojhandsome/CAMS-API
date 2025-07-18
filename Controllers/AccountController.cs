using CAMS_API.Models.DTO.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {
            
        }

        //public async Task<ActionResult<AccountModel>> Register(AccountModel model)
        //{
        //    //var hashedPassword = new PasswordHasher<AccountModel>()
        //    //    .HashPassword(AccountModel, model.Password);


        //}
    }
}
