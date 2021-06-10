using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using LFHSystems.MyFellowGamer.Utils.API;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using LFHSystems.MyFellowGamer.Utils.Cryptography;
using System.Text.RegularExpressions;

namespace LFHSystems.MyFellowGamer.Business
{
    public class UserBusiness : BaseBusiness<UserModel>
    {
        IConfiguration _configuration;
        public UserBusiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserModel SignupNewUser(UserModel pObj)
        {
            pObj.CreationDate = DateTime.Now;
            pObj.PIN = Encryption.EncodePasswordToBase64(pObj.PIN);

            StringContent content = new StringContent(pObj.ToJson(), Encoding.UTF8, "application/json");
            string response = APIConsume.ApiPostAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/Insert", content).Result;

            return pObj;
        }

        //public bool AuthenticateUser(UserModel pObj)
        public bool AuthenticateUser(SignInModel pObj)
        {
            bool email = CheckLoginMethod(pObj.EmailOrUsername);
            string apiMethod = email ? "GetUserByEmail" : "GetUserByUsername";

            string responseEmail = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/{apiMethod}/{pObj.EmailOrUsername}").Result;

            UserModel usr = responseEmail.DeserializeFromJson<UserModel>();

            if (usr != null)
            {
                if (Encryption.DecodePasswordFromBase64(usr.PIN) == pObj.Password)
                    return true;
            }


            return false;
        }

        private bool CheckLoginMethod(string usernameOrEmail)
        {

            if (usernameOrEmail.IndexOf('@') > -1)
            {
                StringBuilder emailRegex = new StringBuilder();
                emailRegex.Append(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}");
                emailRegex.Append(@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\");
                emailRegex.Append(@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

                ////Validate email format
                //string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                //                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                //                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(emailRegex.ToString());
                if (re.IsMatch(usernameOrEmail))
                    return true;
            }

            return false;
            //else
            //{
            //    //validate Username format
            //    string emailRegex = @"^[a-zA-Z0-9]*$";
            //    Regex re = new Regex(emailRegex);
            //    if (!re.IsMatch(model.Email))
            //    {
            //        ModelState.AddModelError("Email", "Username is not valid");
            //    }
            //}

            //return usernameOrEmail.Contains("@");
        }

        public override bool ValidateModel(UserModel pObj)
        {
            if (pObj.Username.IsNullOrEmpty() ||
                pObj.Email.IsNullOrEmpty() ||
                pObj.PIN.IsNullOrEmpty())
                return false;

            //TODO: Add validation for boolean fields (Privacy Policy, TermsOfUse)

            return true;
        }
    }
}
