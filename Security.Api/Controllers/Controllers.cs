using Microsoft.AspNetCore.Mvc;
using Security.Api.Domain.Dto;
using Security.Api.Application;
using Security.Api.Application.AuthToken;

namespace Security.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginRequestDto login, [FromHeader] string Authorization )
        {
            
            SecurityService _securityService = new SecurityService();
            BearerTokenValidation _authService = new BearerTokenValidation();
            if (!_authService.MockValidateToken(Authorization))
            {
                return Unauthorized();
            }

                var ret = _securityService.ValidateLogin(login);
            return Ok(ret);
        }

      
    }
}
