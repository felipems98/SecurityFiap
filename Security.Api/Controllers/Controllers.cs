using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Security.Api.Domain.Dto;
using Security.Api.Application;

namespace Security.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginRequestDto login)
        {
            SecurityService _securityService = new SecurityService();
            var ret = _securityService.ValidateLogin(login);
            return Ok(ret);
        }

      
    }
}
