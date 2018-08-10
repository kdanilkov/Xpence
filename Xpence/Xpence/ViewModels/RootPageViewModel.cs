using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Navigation;
using Xpence.Utility;
using XpenceShared.Base;
using XpenceShared.Models;

namespace Xpence.ViewModels
{
	public class RootPageViewModel : ViewModelBase
    {
        private List<HomeMenuItem> _menuItems= NavigationMap.MenuList;
        public List<HomeMenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }
       
        public RootPageViewModel( INavigationService navigationService, IEventAggregator eventAggregator) :base(navigationService, eventAggregator)
        {
           
            

        }
    }
}
