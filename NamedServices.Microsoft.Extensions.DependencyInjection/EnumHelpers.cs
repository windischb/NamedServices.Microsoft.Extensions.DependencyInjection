using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Reflectensions.Helper
{
    public static class EnumHelpers
    {

        public static string GetFullName(this Enum enumValue) {
            var enumType = enumValue.GetType();
            var enumStringValue = enumValue.ToString("F");
            
            return  $"{enumType.FullName}.{enumStringValue}"; ;
        }



    }

}
