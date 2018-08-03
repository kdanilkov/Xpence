using System.Globalization;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XpenceShared.Config
{
    public class Settings
    {

        private static ISettings AppSettings => CrossSettings.Current;
        public static bool FirstRun
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(FirstRun), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(FirstRun), value.ToString());
        }
        public static CultureInfo SelectedCulture
        {
            get => new CultureInfo(AppSettings.GetValueOrDefault(nameof(SelectedCulture), "en"));

            set => AppSettings.AddOrUpdateValue(nameof(SelectedCulture), value.Name);
        }

    }
}