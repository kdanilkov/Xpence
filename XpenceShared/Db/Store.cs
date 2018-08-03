using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using XpenceShared.Config;
using XpenceShared.Utility;

namespace XpenceShared.Db
{
    public static class Store
    {
        public static async Task InitStore(MobileServiceClient client)
        {
            try
            {
               
                var store = new MobileServiceSQLiteStore(Constants.DbFileName);

                



              // store.DefineTable<UserAccount>(); //INIT all data tables here
                



                //Initializes the SyncContext using the default IMobileServiceSyncHandler.
                var initializeAsync = SharedClient.CurrentClient?.SyncContext.InitializeAsync(store);
                if (initializeAsync != null) await initializeAsync;



#if FAKEDATA
                if (Settings.FirstRun)
                {
                    //Pre-fill tables

                    //wishes
                    var wishesList =  new List<Wish>(FakeDataGenerator.GetWishes());
                    var wishesRepository=App.DryIocContainer.Resolve< IWishesRepository>();
                    foreach (var wish in wishesList)
                    {
                        await wishesRepository.CreateWishAsync(wish);
                    }

                    //if (!Settings.InitialWizardRequired)
                    //{
                        ///else we would never get the accounts list there
                        var accountsSms = FakeDataGenerator.GetAccountsRepositorySms().ToList();

                        var bankAccountsSmsRepository = App.DryIocContainer.Resolve<IBankAccountsSmsRepository>();
                        foreach (var accountSms in accountsSms)
                        {
                            await bankAccountsSmsRepository.CreateAccountAsync(accountSms);
                        }
                   // }

                    

                    var accountsApi = FakeDataGenerator.GetAccountsApiRepository1().ToList();
                    var bankAccountsApi = App.DryIocContainer.Resolve< IBankAccountsApiRepository>();
                    foreach (var accountApi in accountsApi)
                    {
                        await bankAccountsApi.CreateAccountAsync(accountApi);
                    }
                    var banks = FakeDataGenerator.GetDescriptorApiRepositorySms().ToList();
                    var bankAccountsSmsDescriptors = App.DryIocContainer.Resolve<IBankAccountDescriptorSmsRepository>();
                    foreach (var accountDescriptorSms in banks)
                    {
                        await bankAccountsSmsDescriptors.CreateAccountDescriptorAsync(accountDescriptorSms);
                    }

                    var banksApi = FakeDataGenerator.GetDescriptorApiRepositoryApi().ToList();
                    var bankAccountsApiDescriptors = App.DryIocContainer.Resolve<IBankAccountDescriptorApiRepository>();
                    foreach (var accountDescriptorApi in banksApi)
                    {
                        await bankAccountsApiDescriptors.CreateAccountDescriptorAsync(accountDescriptorApi);
                    }

                    var regularPaymentTemplates = FakeDataGenerator.GetRegularPaymentTemplates().ToList();
                    var regularPaymentTemplatesRepository = App.DryIocContainer.Resolve<IRegularPaymentTemplatesRepository>();
                    foreach (var regularPaymentTemplate in regularPaymentTemplates)
                    {
                        await regularPaymentTemplatesRepository.CreateRegularPaymentTemplateAsync(
                            regularPaymentTemplate);
                    }

                    var regularPayments = FakeDataGenerator.GetRegularPayments().ToList();
                    var regularPaymentsRepository = App.DryIocContainer.Resolve<IRegularPaymentsRepository>();
                    foreach (var regularPaymentTemplate in regularPayments)
                    {
                        await regularPaymentsRepository.CreateRegularPaymentAsync(
                            regularPaymentTemplate);
                    }


                    var bankTemplates = FakeDataGenerator.GetBankTemplates().ToList();
                    var bankTemplatesRepository = App.DryIocContainer.Resolve<IBankTemplateRepository>();
                    foreach (var templateBank in bankTemplates)
                    {
                        await bankTemplatesRepository.CreateTemplateAsync(templateBank);
                    }


                    var regularPaymentsPaid = FakeDataGenerator.GetRegularPaymentsPaid().ToList();
                    var regularPaymentsPaidRepository = App.DryIocContainer.Resolve<IRegularPaymentsPaidRepository>();

                    foreach (var regularPaymentPaid in regularPaymentsPaid)
                    {
                        await regularPaymentsPaidRepository.CreateRegularPaymentPaidAsync(regularPaymentPaid);
                    }


                   

                    
                }

#endif
                if (Settings.FirstRun)
                {
                    //Pre-fill tables

                }

                Settings.FirstRun = false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}