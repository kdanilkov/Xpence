#define  DEVELOPMENT_INIT
using System;
using System.Linq;
using Prism;
using Prism.Ioc;
using Xpence.ViewModels;
using Xpence.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using Prism.Modularity;
using Registration;
using Login;
using Prism.Navigation;
using Xpence.Utility;
using XpenceShared.Base.Pages;
using XpenceShared.Contracts;
using XpenceShared.Db;
using XpenceShared.Repositories;
using XpenceShared.Utility;
using XpenceConfig= XpenceShared.Config;
using LoginConfig=Login.Config;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xpence
{

    public partial class App : PrismApplication
    {
        public App() : this(null)
        {
#if DEBUG
            LiveReload.Init();
#endif
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
#if DEBUG
            LiveReload.Init();
#endif
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
#if DEVELOPMENT_INIT

            // Settings.InitialWizardRequired = true;
            XpenceConfig.Settings.WorkOnlyDisconnected = true;
            LoginConfig.Settings.UseScreenLockPin = false;
            LoginConfig.Settings.PinErrorCount = 3;// the first error moves to login
            XpenceConfig.Settings.SyncOnResume = false;
            XpenceConfig.Settings.SyncOnStart = false;
            // check enum picker translation
            XpenceConfig.Settings.SelectedCulture = new System.Globalization.CultureInfo("en");

#endif
            SharedClient.Setup(XpenceConfig.Settings.UID, XpenceConfig.Settings.LastValidToken, LoginConfig.Constants.AzureServerUrl);
            await Store.InitStore(SharedClient.CurrentClient);


            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                //TODO when we will have resources, use the resource file name
                Texts.Culture = ci;
                DependencyService.Get<ILocalize>().SetLocale(ci);
            }

            await NavigationService.NavigateAsync(NavigationMap.OnStartRoutingPage, null, null);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<RootPage>();
            containerRegistry.RegisterForNavigation<SettingsPage>();
            containerRegistry.RegisterForNavigation<OnStartRoutingPage>();
            containerRegistry.RegisterForNavigation<OnStartNotificationPage>();


            containerRegistry.RegisterSingleton<ILogDataRepository, LogDataRepository>();
            containerRegistry.RegisterSingleton<IItemManagerWrapper, ItemManagerWrapper>();
            containerRegistry.RegisterSingleton<IUserAccountRepository, UserAccountRepository>();


        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            ModulesInitializer.ModuleCatalog = moduleCatalog;

            Type registrationModuleType = typeof(RegistrationModule);
            moduleCatalog.AddModule(new ModuleInfo(registrationModuleType, registrationModuleType.Name,InitializationMode.OnDemand));

            Type loginModuleType = typeof(LoginModule);
            moduleCatalog.AddModule(new ModuleInfo(loginModuleType, loginModuleType.Name, InitializationMode.OnDemand));
           

        }
    }
}
