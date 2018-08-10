using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Config;
using Login.Contracts;
using Prism.Events;
using Prism.Navigation;
using XpenceShared.Base;

namespace Login.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
	    public DelegateCommand<string> LoginUsingService { get; }
	    private readonly ILogin _login;
        public LoginPageViewModel(IEventAggregator ea, INavigationService navigationService, ILogin login) : base(navigationService, ea)
        {

            LoginUsingService = NDelegateCommand<string>(async (provider) => await Login(provider));
            _login = login;
        }




        private async Task Login(string provider)
        {

            var result = await _login.LoginUserAsync(provider);

            if (!string.IsNullOrEmpty(XpenceShared.Config.Settings.LastValidToken))
            {
                //we don't need pin immediatly after login
                Settings.PinWasEntered = DateTime.UtcNow;
                // await base.Navigate(NavigationMap.EntryPoint);
                 await Navigate(@"http://myapp.com/NNavigationPage/OnStartRoutingPage");


            }


        }
    }
}
