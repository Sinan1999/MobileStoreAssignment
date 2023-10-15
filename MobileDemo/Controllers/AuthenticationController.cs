using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDemo.Authentication;
using MobileDemo.Service.IService;

namespace MobileDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IBearerAuthentication _bearer;
        private readonly IUserService _userService;

        public AuthenticationController(IBearerAuthentication bearer, IUserService userService)
        {
            _bearer = bearer;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("gettoken")]
        public IActionResult GetToken()
        {
            var data = _bearer.GetToken();
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody]LoginModel loginModel)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.GetUserByUserName(loginModel.User,loginModel.Password);
            if(result != null) 
            {
                var data = _bearer.GetToken();
                return Ok(data);
            }   
            return Unauthorized();
        }

    }
}
