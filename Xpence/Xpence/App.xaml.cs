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

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xpence
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
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

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            Type registrationModuleType = typeof(RegistrationModule);
            moduleCatalog.AddModule(new ModuleInfo(registrationModuleType, registrationModuleType.Name,InitializationMode.OnDemand));

            Type loginModuleType = typeof(LoginModule);
            moduleCatalog.AddModule(new ModuleInfo(loginModuleType, loginModuleType.Name, InitializationMode.OnDemand));


        }
    }
}
