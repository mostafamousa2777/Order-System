using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites.Identity;
using Taskk.Core.Interfaces;

namespace Taskk.Services
{
    public class TokenService : ITokenService
    {
        public readonly IConfiguration _Configuration;
      public readonly UserManager<ApplicationUser> _userManager;
        public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _Configuration = configuration;
            _userManager = userManager;
        }


        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName)

            };
            var roles= await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Token:Key"]));
            var credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor() {
            Subject = new ClaimsIdentity(claims),
            Issuer= _Configuration["Token:Issuer"],
            Expires= DateTime.Now.AddHours(1),
            Audience= _Configuration["Token:Audience"],
            SigningCredentials=credentials



            };
            var jwttoken = new JwtSecurityTokenHandler();
            var token=jwttoken.CreateToken(tokenDescriptor);
            return jwttoken.WriteToken(token);
            


            
        }
    }
}
