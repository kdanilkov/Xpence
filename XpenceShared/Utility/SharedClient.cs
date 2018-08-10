using Microsoft.WindowsAzure.MobileServices;

namespace XpenceShared.Utility
{
    public static class SharedClient
    {
        public static MobileServiceClient CurrentClient { get; private set; }


        public static void Setup(string uid, string lastValidToken, string azureServerUrl)
        {
            CurrentClient = new MobileServiceClient(azureServerUrl)
            {
                CurrentUser = new MobileServiceUser(uid)
                {
                    MobileServiceAuthenticationToken = lastValidToken
                }
            };
        }
    }
}