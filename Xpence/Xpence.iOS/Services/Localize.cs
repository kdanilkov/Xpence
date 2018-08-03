using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Foundation;
using Xamarin.Forms;
using Xpence.iOS.Services;
using XpenceShared.Contracts;
using XpenceShared.Utility;

[assembly: Dependency(typeof(Localize))]

namespace Xpence.iOS.Services
{
    public class Localize : ILocalize
    {
        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = OsToDotnetLanguage(pref);
            }
            // this gets called a lot - try/catch can be expensive so consider caching or something
            CultureInfo ci;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                Debug.WriteLine(e1);
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    Debug.WriteLine(e2);
                    // iOS language not valid .NET culture, falling back to English
                    ci = new CultureInfo("en");
                }
            }
            return ci;
        }

        private static string OsToDotnetLanguage(string iOsLanguage)
        {
            var netLanguage = "en";
            //certain languages need to be converted to CultureInfo equivalent
            switch (iOsLanguage)
            {
                case "ru-US":
                case "ru-GB":
                case "ru-MD":
                case "ru-UA":
                case "ru-RU":
                case "ru":
                    netLanguage = "ru-RU"; 
                    break;
            }
            return netLanguage;
        }

        private static string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            var netLanguage = "en-US"; 
            switch (platCulture.LanguageCode)
            {
                case "ru":
                    netLanguage = "ru-RU"; 
                    break;
                
                // add more application-specific cases here (if required)
                // ONLY use cultures that have been tested and known to work
            }
            return netLanguage;
        }
    }
}