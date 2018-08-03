using Xpence.Attributes;

namespace Xpence.Enums
{
    public enum Currencies:byte
    {
        [CurrencyDetails("Unknown", "--", "--", "-")] Unknown = 0,
        [CurrencyDetails("Emirati Dirham","AED","AED","fils")] Aed =1,
        [CurrencyDetails("Bahraini Dinar","BHD","BD","fils")]Bhd=2,
        [CurrencyDetails("US Dollar", "USD", "$", "¢")] Usd=3,
        [CurrencyDetails("Euro", "Eur", "€", "cent")] Euro=4

         
    }
}