using System;
using System.Reflection;

namespace IpInfo.Api.Utilities
{
    public static class EnumUtility
    {
        public static T ConvertToEnum<T>(this object enumToConvert)
        {
            if (enumToConvert == null)
                return default(T);

            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            T convertedEnum = default(T);

            try
            {
                convertedEnum = (T)Enum.Parse(typeof(T), enumToConvert.ToString(), true);
            }
            catch (Exception) { }

            return convertedEnum;
        }
    }
}
