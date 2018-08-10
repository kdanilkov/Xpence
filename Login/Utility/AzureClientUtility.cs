using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Login.Models;
using Login.Config;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using XpenceShared.Utility;

namespace Login.Utility
{
    public class AzureClientUtility
    {
        private static List<AppServiceIdentity> _identities = null;
        /// <summary>
        /// Azure mobile service client
        /// </summary>
        public MobileServiceClient CurrentClient { get; private set; } = CreateClient();

        /// <summary>
        /// Singleton instance for the ClientUtility
        /// </summary>
        public static AzureClientUtility ClientUtility { get; private set; } = new AzureClientUtility();

        /// <summary>
        /// For Google and Azure 2b2 providers token refresh procedure 
        /// </summary>
        /// <returns></returns>
        public async Task RefreshToken()
        {
            try
            {
                //that is not working for Facebook!!!
                if (!Enum.TryParse(Settings.LoginWithProvider, out MobileServiceAuthenticationProvider provider))
                    provider = MobileServiceAuthenticationProvider.Facebook;
                if (provider == MobileServiceAuthenticationProvider.Google || provider ==
                    MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory)
                {
                    await CurrentClient.RefreshUserAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }
        private static MobileServiceClient CreateClient()
        {

           
            //It is initialized in the app.cs

            return SharedClient.CurrentClient;

        }
        /// <summary>
        /// Returns static instance of the Azure mobile server client
        /// </summary>
        /// <returns></returns>
        public static MobileServiceClient GetClient()
        {
            return ClientUtility.CurrentClient;
        }
        /// <summary>
        /// Check that login token is obsolete
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> IsTokenExpired(string token)
        {
            await ClientUtility.RefreshToken();
            // Get just the JWT part of the token (without the signature).
            var jwt = token.Split('.')[1];

            // Undo the URL encoding.
            jwt = jwt.Replace('-', '+').Replace('_', '/');
            switch (jwt.Length % 4)
            {
                case 0: break;
                case 2: jwt += "=="; break;
                case 3: jwt += "="; break;
                default:
                    throw new ArgumentException("The token is not a valid Base64 string.");
            }

            // Convert to a JSON String
            var bytes = Convert.FromBase64String(jwt);
            var jsonString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            // Parse as JSON object and get the exp field value,
            // which is the expiration date as a JavaScript primative date.
            var jsonObj = JObject.Parse(jsonString);
            var exp = Convert.ToDouble(jsonObj["exp"].ToString());

            // Calculate the expiration by adding the exp value (in seconds) to the
            // base date of 1/1/1970.
            var minTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var expire = minTime.AddSeconds(exp);
            Debug.WriteLine($"Token expiration date {expire}");
            return (expire < DateTime.UtcNow);
        }


        /// <summary>
        /// Initialize the database
        /// </summary>
        /// <returns></returns>
       



        public static async Task<AppServiceIdentity> GetIdentityAsync()
        {
            if (ClientUtility.CurrentClient.CurrentUser == null || ClientUtility.CurrentClient.CurrentUser?.MobileServiceAuthenticationToken == null)
            {
                throw new InvalidOperationException("Not Authenticated");
            }

            if (_identities == null)
            {
                _identities = await ClientUtility.CurrentClient.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
            }

            if (_identities.Count > 0)
                return _identities[0];
            return null;
        }

    }
}