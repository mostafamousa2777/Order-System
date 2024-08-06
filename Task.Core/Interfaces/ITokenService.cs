using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites.Identity;

namespace Taskk.Core.Interfaces
{
    public interface ITokenService
    {
        public Task< string> GenerateToken(ApplicationUser user);
    }
}
