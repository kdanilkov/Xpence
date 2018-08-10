using Prism.Commands;
using Prism.Navigation;
using System.Diagnostics;
using System.Windows.Input;
using Prism.Events;
using Prism.Modularity;
using XpenceShared.Base;

namespace Xpence.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IModuleManager _moduleManager;
        
        public MainPageViewModel(INavigationService navigationService,IEventAggregator eventAggregator, IModuleManager moduleManager, IModuleCatalog moduleCatalog)
            : base(navigationService, eventAggregator)
        {
            
            _moduleManager = moduleManager;
           

            LoadSampleModuleCommand = new DelegateCommand(LoadSampleModule, () => !IsSampleModuleRegistered)
                .ObservesProperty(() => IsSampleModuleRegistered);
            NavigateToSamplePageCommand = new DelegateCommand(NavigateToSamplePage, () => IsSampleModuleRegistered)
                .ObservesProperty(() => IsSampleModuleRegistered);
            NavigateToLoginPageCommand = new DelegateCommand(NavigateToLoginPage, () => IsSampleModuleRegistered)
                .ObservesProperty(() => IsSampleModuleRegistered);
        }

        private bool _isSampleModuleRegistered;
        public bool IsSampleModuleRegistered
        {
            get => _isSampleModuleRegistered;
            set => SetProperty(ref _isSampleModuleRegistered, value);
        }

       
        public ICommand LoadSampleModuleCommand { get; set; }

        public ICommand NavigateToSamplePageCommand { get; set; }

        private void NavigateToSamplePage()
        {
            NavigationService.NavigateAsync("ViewA?par=test");
            
        }
        public ICommand NavigateToLoginPageCommand { get; set; }

        private void NavigateToLoginPage()
        {
           
            NavigationService.NavigateAsync("LoginPage");
        }
        private void LoadSampleModule()
        {
             _moduleManager.LoadModule("RegistrationModule");
            _moduleManager.LoadModule("LoginModule");
            IsSampleModuleRegistered = true;
        }
        
        public override void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public override  void  OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Debug.WriteLine( (string)parameters["title"] + " and Prism");
        }

    }
}
