using System;
using XpenceShared.Config;
using XpenceShared.Contracts;
#if SERVICE

#else
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;


using Xamarin.Forms;
#endif
namespace Xpence.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TranslateAttribute : Attribute
    {
#if SERVICE
        public TranslateAttribute(string word)
        {
            //compatibility
        }
#else




        private readonly CultureInfo _ci;
		private const string ResourceId = Constants.ResourceId;



        private readonly string _word;
		public string Description => getTranslation(_word);

        public TranslateAttribute(string word)
		{
            //Debug.WriteLine(Settings.SelectedCulture);
			_ci = Settings.SelectedCulture ??
				  (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android
					  ? DependencyService.Get<ILocalize>().GetCurrentCultureInfo()
					  : new CultureInfo("en"));
            _word = word;
			
		}

        public string getTranslation(string word)
		{
            if (string.IsNullOrEmpty(word))
				return "";

			var temp = new ResourceManager(ResourceId, typeof(TranslateAttribute).GetTypeInfo().Assembly);
			try
			{
                var translation = temp.GetString(word, _ci);
				if (translation == null)
				{
#if DEBUG
					throw new ArgumentException(
						$"Key '{word}' was not found in resources '{ResourceId}' for culture '{_ci.Name}'.",
						nameof(word));
#else
                translation = word; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
				}
				return translation;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
                return word;
			}
		}
#endif

        }
}

