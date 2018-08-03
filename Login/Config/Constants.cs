using System;

namespace Login.Config
{
    public static class Constants
    {
        /// <summary>
        /// Azure mobile server address
        /// </summary>
        public static string AzureServerUrl => "https://proffy.azurewebsites.net";

        
        /// <summary>
        /// Schema name for Login callbacks
        /// </summary>
        public static string AzureClientSchema => "proffy";

        /// <summary>
        /// The interval when user is not asked for the pin
        /// </summary>
        public static TimeSpan PinTimeout => TimeSpan.FromMinutes(1);


        public static string NavigationSourceKey => "source";
       
    }
}
