using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Login.Contracts;
using Login.Utility;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;
using LoginConfig = Login.Config;
using XpenceShared.Config;


//[assembly: Dependency(typeof(Xpence.iOS.Services.Login))]

namespace Xpence.iOS.Services
{
    public class Login : ILogin
    {
        public async Task<bool> LoginUserAsync(string providerName)
        {

            if (!Enum.TryParse(providerName, out MobileServiceAuthenticationProvider provider))
                provider = MobileServiceAuthenticationProvider.Facebook;


            var client = AzureClientUtility.GetClient();     //    new MobileServiceClient(             Constants.AzureServerUrl                );
            AppDelegate.ResumeWithUrl = url =>
                string.Equals(url.Scheme, LoginConfig.Constants.AzureClientSchema) && client.ResumeWithURL(url);
            try
            {
                var user = await client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,
                    provider, LoginConfig.Constants.AzureClientSchema);

                Settings.LastValidToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UID = user?.UserId ?? string.Empty;
                LoginConfig.Settings.LoginWithProvider = providerName;
                return !string.IsNullOrWhiteSpace(Settings.LastValidToken);
            
            }
            catch (Exception ex)
            {
                //Insights.Report(ex);
                Debug.WriteLine(ex);

                throw;
            }
           
        }

        public async Task<bool> LogoutAsync()
        {
            var client =
                new MobileServiceClient(
                    LoginConfig.Constants.AzureServerUrl
                );

            try
            {
                
                await client.LogoutAsync();

                //TODO clean token in secure store
                Settings.UID = string.Empty;
                Settings.LastValidToken = string.Empty;
                LoginConfig.Settings.LoginWithProvider = string.Empty;

                ClearCookies();
            }
            catch (Exception ex)
            {
                //Insights.Report(ex);
                Debug.WriteLine(ex);
                throw;
            }
            return true;
        }

        public static void ClearCookies()
        {
        }
    }
}