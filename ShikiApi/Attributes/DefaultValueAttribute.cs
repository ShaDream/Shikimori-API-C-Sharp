using System;

namespace ShikiApi
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DefaultValueAttribute : Attribute
    {
        public object DefaultValue { get; }

        public DefaultValueAttribute(object value)
        {
            DefaultValue = value;
        }
    }
}