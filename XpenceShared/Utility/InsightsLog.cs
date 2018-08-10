using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using XpenceShared.Config;
using Microsoft.AppCenter.Analytics;

namespace XpenceShared.Utility
{
    public static class InsightsLog
    {
        public static void UserIdentityLog(string key, string message)
        {
            Debug.WriteLine($"{nameof(UserIdentityLog)}{key} {message}");
            if (Settings.AllowInsightsLog)
            {
               

                Analytics.TrackEvent(
                    "Identity Event",
                    new Dictionary<string, string> { { $"{Settings.UID}_{key}", $"{message}" }, { "time", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture) } }
                  );

            }
        }

        public static void UserLogTrack(string eventName, string key, string message)
        {

            Debug.WriteLine($"{nameof(UserLogTrack)} {eventName} {key} {message}");
            if (Settings.AllowInsightsLog)
            {
                // Insights.Track(eventName, key, Settings.UID + message);

                //and hockey also
                //MetricsManager.TrackEvent(
                //   eventName,
                //    new Dictionary<string, string> { { $"{key}", $"{Settings.UID}_{message}" } , { "time", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture) } },
                //    new Dictionary<string, double> { }
                //);

                Analytics.TrackEvent(
                       eventName,
                       new Dictionary<string, string> { { $"{Settings.UID}_{key}", $"{message}" }, { "time", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture) } }
                     );
            }
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LogError(Exception ex, string methodName)
        {

            Debug.WriteLine($"{nameof(LogError)} {methodName} {ex.Message} {ex.InnerException?.Message} ");

            Analytics.TrackEvent(
                   "Error",
                   new Dictionary<string, string> { { $"{methodName}+{Settings.UID}", $"{ex.Message} inner {ex.InnerException?.Message}" }, { "time", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture) } }
                 );


        }
    }
}