using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using LFHSystems.MyFellowGamer.Utils.API;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using LFHSystems.MyFellowGamer.Utils.Cryptography;

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

        public bool AuthenticateUser(UserModel pObj)
        {


            return false;
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
