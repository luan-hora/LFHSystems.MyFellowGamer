using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace LFHSystems.MyFellowGamer.Interface
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
