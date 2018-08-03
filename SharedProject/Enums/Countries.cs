using Xpence.Attributes;

namespace Xpence.Enums
{
    public enum Countries:byte
    {
        [CountryDetails("Unknown", "--", "--")] Unknown = 0,
        [CountryDetails("Emirates", "United Arab Emirates", "UAE")] Uae=1,
        [CountryDetails("Bahrain", "Kingdom of Bahrain", "BH")]Bahrain=2
    }
}