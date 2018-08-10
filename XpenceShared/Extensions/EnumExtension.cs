using System;
using System.Linq;
using System.Reflection;

namespace XpenceShared.Extensions
{
    public static class EnumExtension
    {
       
            public static TAttribute GetAttribute<TAttribute>(this Enum value)where TAttribute : Attribute
            {
                var type = value.GetType();
                var name = Enum.GetName(type, value);
                return type.GetRuntimeField(name) 
                    .GetCustomAttributes(false)
                    .OfType<TAttribute>()
                    .SingleOrDefault();
            }

       
    }
}