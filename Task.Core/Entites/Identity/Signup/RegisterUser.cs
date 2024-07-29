using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskk.Core.Entites.Identity.Signup
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is Required")]

        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]

        public string? Password { get; set; }


    }
}
