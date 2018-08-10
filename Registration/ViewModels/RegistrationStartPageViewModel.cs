using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Prism.Events;
using Prism.Navigation;
using XpenceShared.Base;

namespace Registration.ViewModels
{
	public class RegistrationStartPageViewModel : ViewModelBase
	{
        public RegistrationStartPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator):base(navigationService,eventAggregator)
        {

        }


	    public override void OnNavigatedTo(NavigationParameters parameters)
	    {
	        base.OnNavigatedTo(parameters);
	        XpenceShared.Config.Settings.InitialRegistrationRequired = false;

	    }
	}
}
