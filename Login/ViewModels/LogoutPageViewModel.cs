using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Login.Contracts;
using Prism.Events;
using Prism.Navigation;
using XpenceShared.Base;
using XpenceShared.Config;
using XpenceShared.Utility;

namespace Login.ViewModels
{
	public class LogoutPageViewModel : ViewModelBase
	{
	    private readonly ILogin _login;
        public LogoutPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, ILogin login): base(navigationService, eventAggregator)
        {
            _login = login;
        }

	    public override async void OnNavigatedTo(NavigationParameters parameters)
	    {
	        IsBusy = true;
	        try
	        {



	            base.OnNavigatedTo(parameters);

	            var authUri = new Uri($"{ Login.Config.Constants.AzureServerUrl}/.auth/logout");
	            using (var httpClient = new HttpClient())
	            {
	                httpClient.DefaultRequestHeaders.Add("X-ZUMO-AUTH",  Settings.LastValidToken);
	                httpClient.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
	                await httpClient.GetAsync(authUri);
	            }
	            await _login.LogoutAsync();
	            await Navigate(@"http://myapp.com/NNavigationPage/OnStartRoutingPage");
            }
	        catch (Exception ex)
	        {

	            InsightsLog.LogError(ex, "Logout_OnNavigatedTo");
	        }
	        finally
	        {
	            IsBusy = false;
	        }


	    }

    }
}
