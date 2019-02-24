using MarketplaceAPI.Model;
using MarketplaceAPI.Business.Implementattions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MarketplaceAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private ILoginBusiness _LoginBusiness;
        public LoginController(ILoginBusiness loginBusiness)
        {
            _LoginBusiness = loginBusiness;
        }

        
        [AllowAnonymous]
        [HttpPost("")]
        public object Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            return _LoginBusiness.FindByLogin(user);

        }

       
    }
}
