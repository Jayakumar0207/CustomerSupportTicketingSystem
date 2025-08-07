using UserAuthService.Application.DTOs;
using UserAuthService.Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAuthServiceController : ControllerBase
    {
        IUserAppService _userAppService;
        public UserAuthServiceController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null || string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
            {
                return BadRequest("Invalid login request.");
            }
            var user = _userAppService.LoginUser(loginDTO);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpDTO userDTO)
        {
            if (userDTO == null || string.IsNullOrEmpty(userDTO.Email) || string.IsNullOrEmpty(userDTO.Password))
            {
                return BadRequest("Invalid registration request.");
            }
            var createdUser = _userAppService.SignUpUser(userDTO);
            return Ok(createdUser);
        }
    }
}
