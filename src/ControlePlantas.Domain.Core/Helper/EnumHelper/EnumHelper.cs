using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ControlePlantas.Domain.Core.Helper
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static Dictionary<int, string> ToDictionary<T>()
            where T : struct
        {
            var enumType = typeof(T);
            return Enum.GetValues(enumType)
                       .Cast<Enum>()
                       .Where(w => (int)(object)w != 0)
                       .ToDictionary(t => (int)(object)t, t => t.ToString());
        }

        public static IEnumerable<KeyValuePair<int, string>> ToKeyValuePair<T>()
            where T : struct
        {
            var enumType = typeof(T);
            return Enum.GetValues(enumType)
                       .Cast<Enum>()
                       .Where(w => (int)(object)w != 0)
                       .Select(t => new KeyValuePair<int, string>((int)(object)t, t.ToString()));
        }
    }
}
