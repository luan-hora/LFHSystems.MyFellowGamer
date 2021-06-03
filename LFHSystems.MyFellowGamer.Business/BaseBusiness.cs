using System;
using System.Collections.Generic;
using System.Text;

namespace LFHSystems.MyFellowGamer.Business
{
    public abstract class BaseBusiness<T>
    {
        public abstract bool ValidateModel(T pObj);
    }
}
