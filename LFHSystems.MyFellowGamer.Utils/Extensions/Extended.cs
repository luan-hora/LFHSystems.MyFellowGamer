using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LFHSystems.MyFellowGamer.Utils.Extensions
{
    public static class Extended
    {
        #region JSON
        public static string ToJson<T>(this T pObj)
        {
            return JsonConvert.SerializeObject(pObj);
        }

        public static T DeserializeFromJson<T>(this string pObj)
        {
            return JsonConvert.DeserializeObject<T>(pObj);
        }
        #endregion

        #region DateTime
        public static DateTime ToDateTime(this object pValue)
        {
            return Convert.ToDateTime(pValue);
        }
        #endregion

        #region Int
        public static int ToInt(this object pValue)
        {
            return Convert.ToInt32(pValue);
        }

        public static int GetBitFromBool(this bool pBool)
        {
            return pBool ? 1 : 0;
        }
        #endregion

        #region Bool
        public static bool IsNullOrEmpty(this string pString)
        {
            return string.IsNullOrEmpty(pString);
        }

        public static bool GetBoolFromBit(this object pValue)
        {
            return pValue.ToInt() == 1;
        }
        #endregion
    }
}
