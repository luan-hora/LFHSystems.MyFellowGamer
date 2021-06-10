using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.WebApp.Models
{
    public class SignInViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Set username or e-mail for sign-in")]
        [Display(Name = "Username or Email")]
        public string EmailOrUsername { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Set your password for authentication")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
