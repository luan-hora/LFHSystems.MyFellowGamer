using System;
using System.Collections.Generic;
using System.Text;

namespace LFHSystems.MyFellowGamer.Model
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PIN { get; set; }
        public bool TermsOfUse { get; set; }
        public bool PrivacyPolicy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
