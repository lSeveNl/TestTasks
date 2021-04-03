using System;
using System.ComponentModel;

namespace Desk.DAL.Extensions
{
    public static class AttributeDescriptionHelper
    {
        public static string GetDescription(this Enum enumeration)
        {
            return ((DescriptionAttribute)enumeration
                .GetType()
                .GetMember(enumeration.ToString())[0]
                .GetCustomAttributes(attributeType: typeof(DescriptionAttribute), inherit: false)[0]).Description;
        }
    }
}
