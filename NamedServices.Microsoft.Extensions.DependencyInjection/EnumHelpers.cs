using System;

namespace NamedServices.Microsoft.Extensions.DependencyInjection
{
    internal static class EnumHelpers
    {

        public static string GetFullName(this Enum enumValue) {
            var enumType = enumValue.GetType();
            var enumStringValue = enumValue.ToString("F");
            
            return  $"{enumType.FullName}.{enumStringValue}"; ;
        }



    }

}
