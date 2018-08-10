using System.Globalization;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XpenceShared.Config
{
    public class Settings
    {

        private static ISettings AppSettings => CrossSettings.Current;
        public static bool UseCloud
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(UseCloud), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(UseCloud), value.ToString());
        }

        public static string LastValidToken
        {
            get => AppSettings.GetValueOrDefault(nameof(LastValidToken), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(LastValidToken), value);
        }
        public static string UID
        {
            get => AppSettings.GetValueOrDefault(nameof(UID), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(UID), value);
        }

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
        public static bool WorkOnlyDisconnected
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(WorkOnlyDisconnected), bool.FalseString));

            set => AppSettings.AddOrUpdateValue(nameof(WorkOnlyDisconnected), value.ToString());
        }

        //share information with the provider
        public static bool ApplicationStoreProfileOnServer
        {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationStoreProfileOnServer), false);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationStoreProfileOnServer), value);
        }

        public static bool ApplicationAgreeToGetPromotions
        {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationAgreeToGetPromotions), false);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationAgreeToGetPromotions), value);
        }

        public static bool ApplicationSubscribeToNotifications
        {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationSubscribeToNotifications), false);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationSubscribeToNotifications), value);
        }

        public static bool ApplicationAgreeToCollectAppStatistics
        {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationAgreeToCollectAppStatistics), false);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationAgreeToCollectAppStatistics), value);
        }

        public static bool ApplicationAgreeToSendAppErrorsToTheCloud
        {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationAgreeToSendAppErrorsToTheCloud), false);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationAgreeToSendAppErrorsToTheCloud), value);
        }

        #region Technical settings
        public static bool SyncOnStart
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(SyncOnStart), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(SyncOnStart), value.ToString());
        }
        public static bool SyncOnResume
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(SyncOnResume), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(SyncOnResume), value.ToString());
        }

        #endregion
        #region Insights, monitoring, log etc.

        /// <summary>
        /// Log information to Xamarin insights cloud
        /// </summary>
        public static bool AllowInsightsLog
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(AllowInsightsLog), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(AllowInsightsLog), value.ToString());
        }
        #endregion

        //wizard
        public static bool InitialWizardRequired
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(InitialWizardRequired), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(InitialWizardRequired), value.ToString());
        }
        //registration
        public static bool InitialRegistrationRequired
        {
            get => bool.Parse(AppSettings.GetValueOrDefault(nameof(InitialRegistrationRequired), bool.TrueString));

            set => AppSettings.AddOrUpdateValue(nameof(InitialRegistrationRequired), value.ToString());
        }
    }
}