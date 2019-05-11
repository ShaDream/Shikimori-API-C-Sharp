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

            return (new[] { type })
                .Concat(type.GetInterfaces())
                .SelectMany(i => i.GetProperties().Where(x => x.CustomAttributes.GetType() == typeof(RequestAttribute)));
        }


        //TODO: not nice. Need to rewrite
        public static bool TryGetKeyValuePair(this PropertyInfo property, object obj, out KeyValuePair<string, string>? value)
        {
            value = null;
            if (property.PropertyType.IsClass)
                if (property.GetValue(obj) != null)
                {
                    value = new KeyValuePair<string, string>(
                        property.GetCustomAttribute<RequestAttribute>().Name,
                        property.GetValue(obj).ToString());
                    return true;
                }
                else
                {
                    if (property.GetCustomAttribute<RequestAttribute>().IsRequired)
                        throw new Exception($"Property {property.Name} is required");
                    return false;
                }

            if (property.PropertyType.IsPrimitive)
                if (!Equals(property.GetValue(obj), property.GetCustomAttribute<RequestAttribute>().DefaultValue))
                {
                    value = new KeyValuePair<string, string>(
                        property.GetCustomAttribute<RequestAttribute>().Name,
                        property.GetValue(obj).ToString());
                    return true;
                }
                else
                {
                    if (property.GetCustomAttribute<RequestAttribute>().IsRequired)
                        throw new Exception($"Property {property.Name} is required");
                    return false;
                }

            if (property.PropertyType.IsEnum)
            {
                value = new KeyValuePair<string, string>(
                    property.GetCustomAttribute<RequestAttribute>().Name,
                    property.GetValue(obj).ToString());
                return true;
            }

            if (!property.IsNullableEnum()) return false;

            if (property.GetValue(obj) == null)
            {
                if (property.GetCustomAttribute<RequestAttribute>().IsRequired)
                    throw new Exception($"Property {property.Name} is required");
                return false;
            }

            if (Nullable.GetUnderlyingType(property.PropertyType).IsEnum)
            {
                var enumType = Nullable.GetUnderlyingType(property.PropertyType);
                var enumValue = typeof(Enum<>).MakeGenericType(enumType).GetMethod("GetName", BindingFlags.Static | BindingFlags.Public)
                    ?.MakeGenericMethod(enumType)
                    .Invoke(null, new[] { property.GetValue(obj) }).ToString();

                value = new KeyValuePair<string, string>(
                    property.GetCustomAttribute<RequestAttribute>().Name,
                    enumValue);
                return true;
            }

            value = new KeyValuePair<string, string>(
                property.GetCustomAttribute<RequestAttribute>().Name,
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