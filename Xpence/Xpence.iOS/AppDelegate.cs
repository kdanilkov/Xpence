using System;
using Foundation;
using Login.Contracts;
using Microsoft.WindowsAzure.MobileServices;
using Prism;
using Prism.Ioc;
using UIKit;


namespace Xpence.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CurrentPlatform.Init();
            Xamarin.Forms.Forms.Init();
            StartAppCenter();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
        public void StartAppCenter()
        {
            Microsoft.AppCenter.AppCenter.Start(
                "ios=f141fd35-8ede-4f1b-89a5-4ee4b6dc29d3",
                typeof(Microsoft.AppCenter.Analytics.Analytics), typeof(Microsoft.AppCenter.Crashes.Crashes));

            Microsoft.AppCenter.Crashes.Crashes.ShouldAwaitUserConfirmation = () => false;
            Microsoft.AppCenter.Crashes.Crashes.ShouldProcessErrorReport = report => true;
            Microsoft.AppCenter.Crashes.Crashes.SetEnabledAsync(true);
            Microsoft.AppCenter.Analytics.Analytics.SetEnabledAsync(true);
            //Microsoft.AppCenter.Crashes.Crashes.GenerateTestCrash();
        }
        #region 
        //TODO move to partial class

        public static Func<NSUrl, bool> ResumeWithUrl;
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return ResumeWithUrl != null && ResumeWithUrl(url);
        }

        #endregion
    }

    // ReSharper disable once InconsistentNaming
    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterInstance<ILogin>(new Services.Login());
        }
    }
}
