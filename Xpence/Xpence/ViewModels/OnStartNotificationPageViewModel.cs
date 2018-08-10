using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xpence.Utility;
using XpenceShared.Base;
using XpenceShared.Utility;

namespace Xpence.ViewModels
{
	public class OnStartNotificationPageViewModel : ViewModelBase
	{
	    private readonly IPageDialogService _dialogService;
        public OnStartNotificationPageViewModel(IPageDialogService dialogService, INavigationService navigationService, IEventAggregator eventAggregator):base(navigationService,eventAggregator)
        {
            _dialogService = dialogService;
        }

	    public override async void OnNavigatedTo(NavigationParameters parameters)
	    {
	        base.OnNavigatedTo(parameters);
	        while (!Connectivity.IsConnected())
	        {
	            await _dialogService.DisplayAlertAsync("Connection issue", "Please check the Internet connection", "Ok");
	        }



	        await Navigate(NavigationMap.EntryPoint);
	    }

    }
}
