using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ShikiApi
{
    public static class RequestExtension
    {
        public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            if (!type.IsInterface)
                return type.GetProperties();

            return (new Type[] { type })
                .Concat(type.GetInterfaces())
                .SelectMany(i => i.GetProperties());
        }

        public static bool TryGetKeyValuePair(this PropertyInfo property, object obj, out KeyValuePair<string, string>? value)
        {
            value = null;
            if (property.PropertyType.IsClass)
                if (property.GetValue(obj) != null)
                {
                    value = new KeyValuePair<string, string>(
                        property.GetCustomAttribute<StringAttribute>().Name,
                        property.GetValue(obj).ToString());
                    return true;
                }
                else
                    return false;

            if (property.PropertyType.IsPrimitive)
                if (!Equals(property.GetValue(obj), property.GetCustomAttribute<DefaultValueAttribute>().DefaultValue))
                {
                    value = new KeyValuePair<string, string>(
                        property.GetCustomAttribute<StringAttribute>().Name,
                        property.GetValue(obj).ToString());
                    return true;
                }
                else
                    return false;

            if (!property.IsNullableEnum()) return false;

            if (property.GetValue(obj) == null) return false;

            if (Nullable.GetUnderlyingType(property.PropertyType).IsEnum)
            {
                var enumType = Nullable.GetUnderlyingType(property.PropertyType);
                var enumValue = typeof(Enum<>).MakeGenericType(enumType).GetMethod("GetName", BindingFlags.Static | BindingFlags.Public)
                    ?.MakeGenericMethod(enumType)
                    .Invoke(null, new[] { property.GetValue(obj) }).ToString();

                value = new KeyValuePair<string, string>(
                    property.GetCustomAttribute<StringAttribute>().Name,
                    enumValue);
                return true;
            }

            value = new KeyValuePair<string, string>(
                property.GetCustomAttribute<StringAttribute>().Name,
                property.GetValue(obj).ToString());
            return true;


        }

        private static bool IsNullableEnum(this PropertyInfo t)
        {
            var u = Nullable.GetUnderlyingType(t.PropertyType);
            return (u != null) && u.IsEnum;
        }
    }
}