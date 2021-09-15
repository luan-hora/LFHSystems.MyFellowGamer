using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LFHSystems.MyFellowGamer.Business
{
    public abstract class BaseBusiness<T>
    {
        public IConfiguration _configuration;
        public BaseBusiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract bool ValidateModel(T pObj);
    }
}
