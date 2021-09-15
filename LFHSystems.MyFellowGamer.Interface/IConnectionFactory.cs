using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LFHSystems.MyFellowGamer.Interface
{
    public interface IConnectionFactory
    {
        IDbConnection ConnString();
    }
}
