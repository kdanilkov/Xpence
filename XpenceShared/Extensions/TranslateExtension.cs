using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XpenceShared.Config;
using XpenceShared.Contracts;

namespace XpenceShared.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo _ci;
        private const string ResourceId = Constants.ResourceId;

        public TranslateExtension()
        {
            //Read culture from settings
            _ci = Settings.SelectedCulture ??
                  (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android
                      ? DependencyService.Get<ILocalize>().GetCurrentCultureInfo()
                      : new CultureInfo("en"));
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var temp = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            try
            {
                var translation = temp.GetString(Text, _ci);
                if (translation == null)
                {
#if DEBUG
                    throw new ArgumentException(
                        $"Key '{Text}' was not found in resources '{ResourceId}' for culture '{_ci.Name}'.",
                        nameof(Text));
#else
				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
                }
                return translation;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Text;
            }
        }
    }
}
