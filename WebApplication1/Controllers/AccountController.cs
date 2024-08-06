using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites.Identity;
using Taskk.Core.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       public readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto dto) {
        
        var user=await _userService.Login(dto);
            return user is not null ? Ok(user) : Unauthorized( new Response() {Status="401",Message="Incorrect Email Or Password" });
        
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
        {

            return Ok(await _userService.Register(dto));

        }

    }
}
