using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace LFHSystems.MyFellowGamer.Interface
{
    public interface ICrud<T>
    {
        void Insert(T pObj);
        void Update(T pObj);
        IEnumerable<T> GetAll();
        T GetByParameter(T pObj);
    }
}
