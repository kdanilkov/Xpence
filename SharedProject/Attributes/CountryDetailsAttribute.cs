using System;

namespace Xpence.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// Attribute to add additional properties to the enum value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class CountryDetailsAttribute:Attribute
    {
        /// <summary>
        /// Human name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Official name
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Like USA, UK
        /// </summary>
        public string CountryCode { get; set; }

      
        /// <inheritdoc />
        /// <summary>
        /// Create instance for the country attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="longName"></param>
        /// <param name="countryCode"></param>
        public CountryDetailsAttribute(string name, string longName, string countryCode)
        {
            Name = name;
            LongName = longName;
            CountryCode = countryCode;
           
            
        }
    }
}