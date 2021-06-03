using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.WebApp.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, set a username value")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        public string PIN { get; set; }
        [Display(Name = "I'm at least 16 years old and accept the Terms of Use")]
        public bool TermsOfUse { get; set; }
        [Display(Name = "I accept the Privacy Policy and consent to the processing of my personal information in accordance with it.")]
        public bool PrivacyPolicy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
