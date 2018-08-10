using System.Collections.Generic;
using XpenceShared.Base.Pages;
using XpenceShared.Models;

namespace Xpence.Utility
{
    public static class NavigationMap
    {

        public static string EntryPoint => $"http://myapp.com/{nameof(RootPage)}/{LandingPage}";

        public static string LandingPage => $"{nameof(NNavigationPage)}/{nameof(Views.MainPage)}";
       // public static string FinancialSettingPage => $"{nameof(NNavigationPage)}/{nameof(Views.AppSettings.FinancialSettingPage)}";
      
        public static string LoginPage => $"http://myapp.com/{nameof(Login.Views.LoginPage)}#LoginModule";

        //public static string PinPage => $"http://myapp.com/{nameof(NNavigationPage)}/{nameof(Views.PinPage)}";
        //public static string PinPage => $"http://myapp.com/{nameof(Views.PinPage)}";
        // public static string PinPage => $"{nameof(NNavigationPage)}/{nameof(Views.PinPage)}#LoginModule";

        public static string RootPage => $"{nameof(NNavigationPage)}/{nameof(Views.RootPage)}";
        
        public static string OnStartRoutingPage => $"http://myapp.com/{nameof(NNavigationPage)}/{nameof(Views.OnStartRoutingPage)}";
        public static string OnStartNotificationPage => $"http://myapp.com/{nameof(Views.OnStartNotificationPage)}";
        public static string LogoutPage => $"{nameof(NNavigationPage)}/{nameof(Login.Views.LogoutPage)}#LoginModule";
        public static string SettingsPage => $"{nameof(NNavigationPage)}/{nameof(Views.SettingsPage)}";
        public static string RegistrationStartPage => $"{nameof(NNavigationPage)}/{nameof(Registration.Views.RegistrationStartPage)}#RegistrationModule";
       



        public static List<HomeMenuItem> MenuList => new List<HomeMenuItem>
        {
            new HomeMenuItem
            {
                Title = Texts.MenuHome,
                NavigateUrl = LandingPage,
                Icon="ic_home.png"
            },
            
            new HomeMenuItem
            {
                Title = Texts.MenuSettings,
                //NavigateUrl = NavigationMap.UserDataSettingPage,
                NavigateUrl = SettingsPage,
                Icon="ic_setting.png"
            },
            new HomeMenuItem
            {
                Title = Texts.MenuLogout,
                NavigateUrl = LogoutPage,
                Icon="ic_logout.png"
            }
        };


    }
}