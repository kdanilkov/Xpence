using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Prism.Modularity;

namespace Xpence.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigatedAware
    {
        private readonly IModuleManager _moduleManager;
        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService, IModuleManager moduleManager, IModuleCatalog moduleCatalog)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _moduleManager = moduleManager;
            Title = "Main Page";

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
            _navigationService.NavigateAsync("ViewA?par=test");
            
        }
        public ICommand NavigateToLoginPageCommand { get; set; }

        private void NavigateToLoginPage()
        {
           
            _navigationService.NavigateAsync("LoginPage");
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
                Title = (string)parameters["title"] + " and Prism";
        }

    }
}
