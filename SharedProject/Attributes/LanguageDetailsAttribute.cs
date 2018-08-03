using System;

namespace Xpence.Attributes
{
    /// <inheritdoc />
    /// <summary>
    ///     Attribute to add additional properties to the enum value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class LanguageDetailsAttribute : Attribute
    {
        /// <summary>
        ///     Human name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        ///     Like "en-en"
        /// </summary>
        public string Code { get; set; }


        /// <inheritdoc />
        /// <summary>
        ///     Create instance for the language attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        public LanguageDetailsAttribute(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}