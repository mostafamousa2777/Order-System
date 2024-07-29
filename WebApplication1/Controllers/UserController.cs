using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Taskk.Core.Entites.Identity;
using Taskk.Core.Entites.Identity.Signup;



namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterUser registerUser) {
            var userExist=await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist!=null) {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status="Error",Message="User alredy Exsist"}
                    );
            
            }
            ApplicationUser user = new()
            {
                Email = registerUser.Email,
                UserName = registerUser.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),

            };
            var result=await _userManager.CreateAsync(user,registerUser.Password);

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "good", Message = "User Created" }
                    );

            }
            else {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "User faild to Create" }
                        );


            }
        
        
        }

    }
}
