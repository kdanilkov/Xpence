/*
 * To add Offline Sync Support:
 *  1) Add the NuGet package Microsoft.Azure.Mobile.Client.SQLiteStore (and dependencies) to all client projects
 *  2) Uncomment the #define OFFLINE_SYNC_ENABLED
 *
 * For more information, see: http://go.microsoft.com/fwlink/?LinkId=620342
 */
#define OFFLINE_SYNC_ENABLED

using Microsoft.WindowsAzure.MobileServices.Sync;
using XpenceShared.Models;
using XpenceShared.Utility;

#if OFFLINE_SYNC_ENABLED

#endif

namespace XpenceShared.Repositories
{
    public  class ItemManager<T> where T: BaseModel
    {


        public IMobileServiceSyncTable<T> Table
        {
            get
            {
                var client = SharedClient.CurrentClient;
                var table=client?.GetSyncTable<T>();
                return table;
            }

            
        } 

        
       
        public static ItemManager<T> DefaultManager { get; private set; } =  new ItemManager<T>();

       
    }
}
