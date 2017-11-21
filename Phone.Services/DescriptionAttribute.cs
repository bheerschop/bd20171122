using System;
using System.Reflection;

namespace Phone.Enums
{
    /// <summary>
    /// Description Metadata for a Field. Used for Enumerations.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DescriptionAttribute : Attribute
    {
        readonly string description;

        public DescriptionAttribute(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// A User friendly description
        /// </summary>
        public string Description
        {
            get { return description; }
        }
    }

    public static class EnumsExtensions {
        /// <summary>
        /// Gets the Description Attribute Value eventually applied to an Enumeration
        /// </summary>
        /// <param name="value">The Enumeration field to which the Description has been applied to</param>
        /// <returns>The Description Attribute value applied to an Enumeration if present, the original value of the Enum field otherwise</returns>
        public static string GetDescription(this Enum value) {
            Type enumType = value.GetType();
            FieldInfo field = enumType.GetField(value.ToString());
            Attribute attribute = field.GetCustomAttribute(typeof(DescriptionAttribute));
            
            // return  
            return attribute==null ? value.ToString() : ((DescriptionAttribute)attribute).Description;
        }
    }
}
