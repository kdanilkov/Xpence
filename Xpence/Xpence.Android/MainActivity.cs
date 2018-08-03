using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Login.Contracts;
using Microsoft.WindowsAzure.MobileServices;
using Prism;
using Prism.Ioc;



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

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

       
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
            container.RegisterInstance<ILogin>(new Services.Login());
        }
    }
}

