using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using XpenceShared.Events;

namespace XpenceShared.Base
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected DelegateCommand<string> NavigateCommand => new DelegateCommand<string>(async (url)=>await Navigate(url));

        protected DelegateCommand<string> NavigateModalCommand => new DelegateCommand<string>(async (url) => await Navigate(url,true));

        protected DelegateCommand NavigateBack => new DelegateCommand(async()=>await GoBack());
        protected DelegateCommand NavigateBackModal => new DelegateCommand(async () => 
                                                                        await GoBack(modal:true)
                                                                       );
        protected INavigationService NavigationService;
        protected IEventAggregator Ea;
        protected async Task GoBack(bool modal = false)
        {
            var goBackAsync = NavigationService?.GoBackAsync(animated: false, useModalNavigation: modal);
            if (goBackAsync != null)
                await goBackAsync;
        }


        protected ViewModelBase()
        {
            
        }
        protected ViewModelBase(INavigationService navigationService, IEventAggregator ea)
        {
            NavigationService = navigationService;
            Ea = ea;
        }
        protected virtual Task Navigate(string name, bool? modal=null, NavigationParameters navigationParameters=null)
        {
            return  Task.Run(() => Device.BeginInvokeOnMainThread(async () =>
            {
                var navigateAsync = NavigationService?.NavigateAsync(name,parameters: navigationParameters, useModalNavigation:modal, animated: false);
                if (navigateAsync != null)
                    await navigateAsync;
            }));

           // return NavigationService?.NavigateAsync(name, animated: false);
        }
        public  DelegateCommand ShowMenuCommand => NannyDelegateCommand(async () =>
        {
            await Task.CompletedTask.ConfigureAwait(false);
            Ea?.GetEvent<ShowMenuEvent>().Publish(true);
            
        });


        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public virtual async Task RefreshData()
        {
            //todo _isBusy
            //todo indicator
            await Task.CompletedTask;
            
        }
        private DelegateCommand _refresh;
        public DelegateCommand Refresh => _refresh ?? (_refresh = NannyDelegateCommand(async () =>
        {
            await RefreshData();
        }));
        private  bool _isBusy;

        public  bool IsBusy
        {
            get => _isBusy;

            set => SetProperty(ref _isBusy, value);
        }


        protected DelegateCommand<T> NannyDelegateCommand<T>(Func<T, Task> origin)
        {
            var result = new DelegateCommand<T>(async x =>
                {
                    var methodname = origin.GetMethodInfo().ToString();
                    try
                    {
                        
                        
                        //Helper.InsightsLog.UserLogTrack($"Command {methodname}",methodname, x.ToString());
                        Debug.WriteLine(origin.GetMethodInfo().ToString());
                        IsBusy = true;
                        await origin(x);
                    }
                    catch (InvalidOperationException e)
                    {

                        var message =
                            $"{nameof(NannyDelegateCommand)} {nameof(origin)} {x.ToString()} {methodname} Failed with exception: {e.Message}";
                       // Helper.InsightsLog.UserLogTrack($"CommandError {methodname}", methodname, message);
                       
                        Debug.WriteLine(message);
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                },
                CanExecuteMethod).ObservesProperty(() => IsBusy);

            return result;
        }


        protected DelegateCommand NannyDelegateCommand(Func<Task> origin)
        {
            var methodname = origin.GetMethodInfo().ToString();
            var result = new DelegateCommand(async () =>
            {
                try
                {
                  
                    //Helper.InsightsLog.UserLogTrack($"Command {methodname}", methodname, Settings.UID);
                    Debug.WriteLine(methodname + origin.GetMethodInfo());

                    IsBusy = true;
                    await origin();
                }
                catch (InvalidOperationException e)
                {
                    var message =
                        $"{nameof(NannyDelegateCommand)} {nameof(origin)} {methodname} Failed with exception: {e.Message}";
                   // Helper.InsightsLog.UserLogTrack($"CommandError {methodname}",methodname, message);
                   
                    Debug.WriteLine(message);
                    
                }
                finally
                {
                    IsBusy = false;
                }
            }, CanExecuteMethod).ObservesProperty(() => IsBusy);

            return result;
        }


        private bool CanExecuteMethod()
        {
            return !IsBusy;
        }
        private bool CanExecuteMethod<T>(T x)
        {
            return !IsBusy;
        }
    }
}
