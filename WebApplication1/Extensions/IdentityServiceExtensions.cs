using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Taskk.Core.Entites.Identity;
using Taskk.Repository.Data;

namespace WebApplication1.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection Services,IConfiguration Configuration)
        {
            Services.AddIdentityCore<ApplicationUser>().
                AddEntityFrameworkStores<IdentityDataContext>().AddSignInManager<SignInManager<ApplicationUser>>();
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => {
                option.TokenValidationParameters = new TokenValidationParameters() { 
                ValidateIssuer = true,
                ValidIssuer= Configuration["Token:Issuer"],
                ValidateIssuerSigningKey=true,
                IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"])),
                ValidateAudience=true,
                ValidAudience= Configuration["Token:Audience"],
                ValidateLifetime=true

                };
            
            
            });

            return Services;
        }

    }
}
