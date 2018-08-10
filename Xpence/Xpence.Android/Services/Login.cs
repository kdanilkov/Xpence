using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XpenceShared.Config;
using LoginConfig =Login.Config;
using Login.Contracts;
using Login.Utility;
using Microsoft.WindowsAzure.MobileServices;

//[assembly: Dependency(typeof(Xpence.Droid.Services.Login))]

namespace Xpence.Droid.Services
{
    public class Login : ILogin
    {
        public Login()
        {
            Debug.Write("Login constructor");
        }

        public async Task<bool> LoginUserAsync(string providerName)
        {


            var context = Android.App.Application.Context;
            if (!Enum.TryParse(providerName, out MobileServiceAuthenticationProvider provider))
                provider = MobileServiceAuthenticationProvider.Facebook;


            var client = AzureClientUtility.GetClient();     // new MobileServiceClient(Constants.AzureServerUrl);

            try
            {
                
                var user = await client.LoginAsync(context, provider, LoginConfig.Constants.AzureClientSchema);
                
                Settings.LastValidToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UID = user?.UserId ?? string.Empty;
                LoginConfig.Settings.LoginWithProvider = providerName;
                return !string.IsNullOrWhiteSpace(Settings.LastValidToken);

            }
            catch (Exception ex)
            {
               
                Debug.WriteLine(ex);
                throw ;
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
                //ClearCookies();
                await client
                    .LogoutAsync(); // LoginAsync(Forms.Context, MobileServiceAuthenticationProvider.Facebook, "nanny");

                //TODO clean token in secure store
                Settings.UID = string.Empty;
                Settings.LastValidToken = string.Empty;
                LoginConfig.Settings.LoginWithProvider = string.Empty;
                
                //  ClearCookies();
            }
            catch (Exception ex)
            {
               
                Debug.WriteLine(ex);
                throw;
            }
            return true;
        }

        //public static void ClearCookies()
        //{
        //    //if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
        //    //    Android.Webkit.CookieManager.Instance.RemoveAllCookies(null);
        //    //else
        //    //    Android.Webkit.CookieManager.Instance.RemoveAllCookie();

        //    if (CookieManager.Instance.HasCookies)
        //    {
                
        //    }
        //}
    }
}