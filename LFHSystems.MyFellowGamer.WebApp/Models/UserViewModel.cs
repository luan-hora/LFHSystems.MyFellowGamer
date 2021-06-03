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
        public string Username { get; set; }
        public string Email { get; set; }
        public string PIN { get; set; }
        public bool TermsOfUse { get; set; }
        public bool PrivacyPolicy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
