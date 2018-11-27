using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace ShikiApi
{
    public class Enum<T> where T : struct, IConvertible
    {
        public static string GetName<T>(T value)
        {
            if (value == null)
                return null;
            var mem = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Static).Single(m => m.Name == Enum.GetName(typeof(T), value));
            var attr = mem.GetCustomAttribute<EnumMemberAttribute>();
            return attr != null ? attr.Value : mem.Name;
        }
    }
}