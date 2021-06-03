using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using System;

namespace LFHSystems.MyFellowGamer.Business
{
    public class UserBusiness : BaseBusiness<UserModel>
    {
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
