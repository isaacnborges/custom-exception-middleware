using System;

namespace CustomExceptionMiddleware.Extensions
{
    public static class EnumExtensions
    {
        public static int GetIntValue(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
    }
}
