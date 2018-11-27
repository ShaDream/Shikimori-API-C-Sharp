using System;

namespace ShikiApi
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringAttribute : Attribute
    {
        public StringAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}