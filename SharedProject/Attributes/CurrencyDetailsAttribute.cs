using System;

namespace Xpence.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// Attribute to add additional properties to the enum value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class CurrencyDetailsAttribute:Attribute
    {
        /// <summary>
        /// Human name Like US Dollar
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Currency code like "USD"
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Currency symbol like $
        /// </summary>
        public string Symbol { get; set; }

        public string Cent { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Create instance of the Currency attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="symbol"></param>
        /// <param name="cent"></param>
        public CurrencyDetailsAttribute(string name, string code, string symbol, string cent)
        {
            Name = name;
            Code = code;
            Symbol = symbol;
            Cent = cent;
        }
    }
}