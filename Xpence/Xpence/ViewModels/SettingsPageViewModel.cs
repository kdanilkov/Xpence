using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Navigation;
using XpenceShared.Base;
using XpenceShared.Base.Pages;

namespace Xpence.ViewModels
{
	public class SettingsPageViewModel : ViewModelBase
	{
        public SettingsPageViewModel(INavigationService navigationService,IEventAggregator eventAggregator):base(navigationService,eventAggregator)
        {

        }
	}
}
