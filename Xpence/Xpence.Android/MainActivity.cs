using Android.App;
using Android.Content.PM;
using Android.OS;
using Login.Contracts;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism;
using Prism.Ioc;
using XpenceShared.Contracts;
using XpenceShared.Repositories;
using Permission = Android.Content.PM.Permission;


namespace Xpence.Droid
{
    [Activity(Label = "Xpence", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            CurrentPlatform.Init();
            base.OnCreate(bundle);
            
            SetCrashManager();
            Xamarin.Forms.Forms.Init(this, bundle);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            Window.SetBackgroundDrawable(null);
        }
        private void SetCrashManager()
        {
            StartAppCenter();

            if (CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location).GetAwaiter().GetResult() != PermissionStatus.Granted
                || CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Sms).GetAwaiter().GetResult() != PermissionStatus.Granted
                || CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage).GetAwaiter().GetResult() != PermissionStatus.Granted


            )
            {
                CrossPermissions.Current.RequestPermissionsAsync(
                    Plugin.Permissions.Abstractions.Permission.Sms,
                    Plugin.Permissions.Abstractions.Permission.Location
                    , Plugin.Permissions.Abstractions.Permission.Storage
                );

            }

            //throw  new Exception("fake test");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void StartAppCenter()
        {
            Microsoft.AppCenter.AppCenter.Start("android=4f2b180d-b6a9-4954-8f86-1f44357ce35d;",
                typeof(Microsoft.AppCenter.Analytics.Analytics), typeof(Microsoft.AppCenter.Crashes.Crashes));

            Microsoft.AppCenter.Crashes.Crashes.ShouldAwaitUserConfirmation = () => false;
            Microsoft.AppCenter.Crashes.Crashes.ShouldProcessErrorReport = report => true;
            Microsoft.AppCenter.Crashes.Crashes.SetEnabledAsync(true);
            Microsoft.AppCenter.Analytics.Analytics.SetEnabledAsync(true);
            //Microsoft.AppCenter.Crashes.Crashes.GenerateTestCrash();
        }

    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
            // container.RegisterInstance<ILogin>(new Services.Login());
            container.RegisterSingleton<ILogin, Services.Login>();
        }
    }
}

