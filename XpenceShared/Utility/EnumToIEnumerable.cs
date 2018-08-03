using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Xpence.Attributes;

namespace XpenceShared.Utility
{
    public static class EnumHelper
    {
		public static IEnumerable ToEnumerable (Type enumType)
        {
			//var enums = Enum.GetValues(enumType).Cast<object>().Select(e => new { Value = (byte)e, DisplayName = getDescription(e),Name = e.ToString()});
            var enums = Enum.GetValues(enumType).Cast<object>().Select(GetDescription);

            return enums;
        }

        private static string GetDescription(object e)
        {
            var fieldInfo = e.GetType().GetRuntimeField(e.ToString());
            var attribArrays = fieldInfo.GetCustomAttributes(false).ToList();

            if (!attribArrays.Any())
                return e.ToString();

            foreach (var array in attribArrays.OfType<TranslateAttribute>())
            {
                return array.Description;
            }

            return e.ToString();
        }
    }
}
