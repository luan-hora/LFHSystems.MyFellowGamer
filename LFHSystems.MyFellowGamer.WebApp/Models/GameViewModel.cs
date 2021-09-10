using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.WebApp.Models
{
    public class GameViewModel
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, set a username value")]
        [Display(Name = "Username")]
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public string PlatformsAvailable { get; set; }
        public string DeveloperId { get; set; }
        public string PublisherId { get; set; }

        //[EmailAddress(ErrorMessage = "E-mail is not valid format")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please, set an e-mail")]
        //[Display(Name = "Email Address")]
        //public string Email { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please, create your password")]
        //[Display(Name = "Password")]
        //public string PIN { get; set; }

        //#region Boolean fields validation
        //public bool IsTrue
        //{ get { return true; } }

        //[Compare("IsTrue", ErrorMessage = "Please agree to Terms of Use")]
        //[Display(Name = "I'm at least 16 years old and accept the Terms of Use")]
        //public bool TermsOfUse { get; set; }

        //[Compare("IsTrue", ErrorMessage = "Please agree to the Privacy Policy")]
        //[Display(Name = "I accept the Privacy Policy and consent to the processing of my personal information in accordance with it.")]
        //public bool PrivacyPolicy { get; set; }
        //#endregion

        //public DateTime CreationDate { get; set; }

    }
}
