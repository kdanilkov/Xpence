using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Login.Utility;
using Prism.Events;
using Prism.Modularity;
using Prism.Navigation;
using Xpence.Enums;
using Xpence.Utility;
using XpenceShared.Base;
using XpenceShared.Contracts;
using XpenceShared.Db;
using XpenceShared.Utility;
using XpenceConfig = XpenceShared.Config;
using LoginConfig = Login.Config;

namespace Xpence.ViewModels
{
    public class OnStartRoutingPageViewModel : ViewModelBase
    {

        private readonly IItemManagerWrapper _itemManagerWrapper;
       
       
        public OnStartRoutingPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IModuleManager moduleManager, IItemManagerWrapper itemManagerWrapper) :
            base(navigationService, eventAggregator)
        {
            
            _itemManagerWrapper = itemManagerWrapper;
            ModulesInitializer.ModuleManager = moduleManager;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            IsBusy = true;
            base.OnNavigatedTo(parameters);
            await Init(parameters);//.ConfigureAwait(false);
            IsBusy = false;
        }
        private async Task Init(NavigationParameters navigationParameters)
        {
            try
            {
                

                var source = navigationParameters.ContainsKey(LoginConfig.Constants.NavigationSourceKey) ? navigationParameters[LoginConfig.Constants.NavigationSourceKey].ToString() : string.Empty;


                SharedClient.Setup(XpenceConfig.Settings.UID, XpenceConfig.Settings.LastValidToken, LoginConfig.Constants.AzureServerUrl);
                await Store.InitStore(SharedClient.CurrentClient).ConfigureAwait(false);


                //user can disable cloud synchronization


                //If connected to internet we will refresh data with azure and refresh tokens
                if (Connectivity.IsConnected())
                    if (!string.IsNullOrWhiteSpace(XpenceConfig.Settings.LastValidToken))
                    {
                        //we have saved token and have to check it and refresh
                        //we need the Token

                        var tokenExpired = await AzureClientUtility.IsTokenExpired(XpenceConfig.Settings.LastValidToken);
                        Debug.WriteLine($"Token expired {tokenExpired}");
                        if (tokenExpired)
                        {
                            await NavigateToLogin();
                        }
                        else
                        {


                            //check that we have time interval passed after the previous pin
                            if (PinRequired())
                            {
                                //Pin was entered with error more then N times. redirect to login page
                                //later user could change the pin
                                //in application settings
                                if (string.Equals(source, PinViewResults.PinError.ToString()))
                                {
                                    await NavigateToLogin();
                                }
                                else
                                {
                                    await NavigateToPin();
                                }

                            }
                            else
                            {

                                //check that we need to call initial application wizard
                                if (XpenceConfig.Settings.InitialRegistrationRequired)
                                {
                                    await NavigateRegistration();
                                }
                                else
                                {
                                   

                                   
                                    if (XpenceConfig.Settings.SyncOnStart)
                                        await _itemManagerWrapper.SyncAllAsync();

                                    //navigate to app

                                    await Navigate(NavigationMap.EntryPoint);
                                }
                            }
                        }
                    }
                    else
                    {
                        await NavigateToLogin();
                    }
                else
                    await Navigate(NavigationMap.OnStartNotificationPage, null, navigationParameters);
            }
            catch (AggregateException ex)
            {
                Debug.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private static bool PinRequired()
        {
            return LoginConfig.Settings.UseScreenLockPin &&
                   (LoginConfig.Settings.PinWasEntered == null || (DateTime.UtcNow - LoginConfig.Settings.PinWasEntered).Value >
                    LoginConfig.Constants.PinTimeout);
        }

        private async Task NavigateToPin()
        {
           
            await Navigate($"{NavigationMap.LoginPage}", true);//pin page
        }

        private async Task NavigateRegistration()
        {

           

            await Navigate($"{NavigationMap.RegistrationStartPage}");

        }

        
        private async Task NavigateToLogin()
        {

          

            await Navigate($"{NavigationMap.LoginPage}");
        }

    }
}
