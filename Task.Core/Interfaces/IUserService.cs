using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.DataTransferObjects;

namespace Taskk.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> Login(LoginDto dto);
        Task<UserDto?> Register(RegisterDto dto);

    }
}
