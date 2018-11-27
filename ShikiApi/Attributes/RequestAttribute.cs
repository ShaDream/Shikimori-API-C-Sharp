using System;

namespace ShikiApi
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequestAttribute : Attribute
    {
        public object DefaultValue { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; } = false;
    }
}