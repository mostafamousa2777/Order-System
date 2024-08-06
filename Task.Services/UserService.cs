using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites.Identity;
using Taskk.Core.Interfaces;

namespace Taskk.Services
{
    public class UserService : IUserService
    {
        public readonly UserManager<ApplicationUser> _usermanger;
        public readonly ITokenService _tokenService;
        public readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> usermanger, ITokenService tokenService, SignInManager<ApplicationUser> signInManager)
        {
            _usermanger = usermanger;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<UserDto?> Login(LoginDto dto)
        {
           var user=await _usermanger.FindByEmailAsync(dto.Email);
            if (user!=null) {
              var result=await _signInManager.CheckPasswordSignInAsync(user, dto.Password,false);
                if(result.Succeeded) {

                    return new UserDto() {
                    DisplayName=user.UserName,
                    Email=user.Email,
                    Token=await _tokenService.GenerateToken(user)

                    
                    };
                }
            }
            return null;
        }

        public async Task<UserDto?> Register(RegisterDto dto)
        {
            var user = await _usermanger.FindByEmailAsync(dto.Email);
           
            if (user!=null) 
                throw new Exception("Email Already Exist ");
            var appuser = new ApplicationUser() {
            UserName=dto.DisplayName,
            Email=dto.Email,
           
            
            };
            var resualt=await _usermanger.CreateAsync(appuser,dto.Password);
            if (!resualt.Succeeded) 
                throw new Exception("failed to creat user  ");

            return new UserDto()
            {
                DisplayName = appuser.UserName,
                Email = appuser.Email,
                Token =await _tokenService.GenerateToken(appuser)


            };





        }
    }
}
