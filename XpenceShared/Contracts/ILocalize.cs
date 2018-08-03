using System.Globalization;

namespace XpenceShared.Contracts
{
    public interface ILocalize
    {

            CultureInfo GetCurrentCultureInfo();
            void SetLocale(CultureInfo ci);
        
    }
}