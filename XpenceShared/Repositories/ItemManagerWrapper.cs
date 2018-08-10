using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using XpenceShared.Contracts;
using XpenceShared.Models;
using XpenceShared.Repositories;
using XpenceShared.Utility;

[assembly: Dependency(typeof(ItemManagerWrapper))]

namespace XpenceShared.Repositories
{
    public class ItemManagerWrapper : IItemManagerWrapper
    {
        public async Task<ObservableCollection<T>> GetObservableCollectinAsync<T>(Expression<Func<T, bool>> predicate,
            bool syncItems = false) where T : BaseModel
        {
            try
            {
                return new ObservableCollection<T>(await GetEnumeratorAsync(predicate, syncItems));
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine($@"Invalid {nameof(GetObservableCollectinAsync)} {typeof(T)}: {msioe.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($@"Invalid {nameof(GetObservableCollectinAsync)}  {typeof(T)}: {e.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetEnumeratorAsync<T>(Expression<Func<T, bool>> predicate,
            bool syncItems = false) where T : BaseModel
        {
            try
            {
                if (syncItems)
                    await SyncSingleTableAsync<T>();
                //todo allow predictors use

                if (predicate == null)
                    return await ItemManager<T>.DefaultManager.Table
                        // .Where(predicate)
                        .ToEnumerableAsync();
                return await ItemManager<T>.DefaultManager.Table
                    .Where(predicate)
                    .ToEnumerableAsync();
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine($@"Invalid {nameof(GetEnumeratorAsync)}  {typeof(T)}: {msioe.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($@"Invalid {nameof(GetEnumeratorAsync)} {typeof(T)}: {e.Message}");
                throw;
            }
        }

        public async Task<int> GetCountAsync<T>(Expression<Func<T, bool>> predicate, bool syncItems = false)
            where T : BaseModel
        {
            try
            {
                if (syncItems)
                    await SyncSingleTableAsync<T>();
                var tbl = ItemManager<T>.DefaultManager.Table;

                var cnt = await tbl.ToEnumerableAsync().ContinueWith(x => x.Result.Count());
                return cnt;
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine($@"Invalid {nameof(GetCountAsync)} {typeof(T)}: {msioe.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($@"Invalid {nameof(GetCountAsync)}  {typeof(T)}: {e.Message}");
                throw;
            }
        }

        public async Task<T> GetLookupAsync<T>(string id, bool syncItems = false) where T : BaseModel
        {
            try
            {
                if (syncItems)
                    await SyncSingleTableAsync<T>();
                var tbl = ItemManager<T>.DefaultManager.Table;
                var result = await tbl.LookupAsync(id);
                return result;
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine($@"Invalid {nameof(GetLookupAsync)}  {typeof(T)}: {msioe.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($@"Invalid {nameof(GetLookupAsync)}  {typeof(T)}: {e.Message}");
                throw;
            }
        }

        public async Task UpsertBatch<T>(IList<T> items, bool syncItems = false) where T : BaseModel
        {
            var serializer = new JsonSerializer {ContractResolver = new MobileServiceContractResolver()};
            IList<JObject> target = new List<JObject>();
            foreach (var i in items)
            {
                var ij = JObject.FromObject(i);//, serializer);
                target.Add(ij);
            }

            var tablName = typeof(T).Name;
           
            await SharedClient.CurrentClient.SyncContext.Store.UpsertAsync(tablName,
                target, false);
        }

        public async Task SaveTaskAsync<T>(T item, bool syncItems = false) where T : BaseModel
        {
            try
            {
                
                if (item.Id == null)
                    await ItemManager<T>.DefaultManager.Table.InsertAsync(item);
                else
                    await ItemManager<T>.DefaultManager.Table.UpdateAsync(item);
                if (syncItems)
                    await SyncSingleTableAsync<T>();
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine($@"Invalid {nameof(SaveTaskAsync)}  {typeof(T)}: {msioe.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($@"Invalid {nameof(SaveTaskAsync)}  {typeof(T)}: {e.Message}");
                throw;
            }
        }

        public async Task DeleteTaskAsync<T>(T item, bool syncItems = false) where T : BaseModel
        {
            try
            {
                if (syncItems)
                    await SyncSingleTableAsync<T>();
                if (item?.Id == null)
                    throw new Exception("Item to be deleted must be not null and with ID");

                await ItemManager<T>.DefaultManager.Table.DeleteAsync(item);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine($@"Invalid {nameof(DeleteTaskAsync)}  {typeof(T)}: {msioe.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($@"Invalid {nameof(DeleteTaskAsync)}  {typeof(T)}: {e.Message}");
                throw;
            }
        }

        public async Task SyncSingleTableAsync<T>() where T : BaseModel
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                //await ItemManager<T>.DefaultManager.CurrentClient.SyncContext.PushAsync();
                var pushAsync
                    = SharedClient.CurrentClient?.SyncContext.PushAsync();
                if (pushAsync != null)
                    await pushAsync;


                await SyncTableAsync<T>();
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                    syncErrors = exc.PushResult.Errors;
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                        await error.CancelAndUpdateItemAsync(error.Result);
                    else
                        await error.CancelAndDiscardItemAsync();

                    Debug.WriteLine(
                        $@"Error executing sync operation. {nameof(SyncSingleTableAsync)} {typeof(T)} Item: {
                                error.TableName
                            }   ({error.Item["id"]}). Operation discarded.");
                }
        }

        private async Task SyncTableAsync<T>() where T : BaseModel
        {
            var syncName = typeof(T).Name;
            await ItemManager<T>.DefaultManager.Table.PullAsync(
                //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                //Use a different query name for each unique query in your program
                syncName,
                ItemManager<T>.DefaultManager.Table.CreateQuery());
        }

        public async Task SyncAllAsync()
        {
            //todo filter on valid sync by user, as user can disable sync for sensitive data


            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                //await ItemManager<T>.DefaultManager.CurrentClient.SyncContext.PushAsync();
                var pushAsync
                    = SharedClient.CurrentClient?.SyncContext.PushAsync();
                if (pushAsync != null)
                    await pushAsync;


                var listOfTables = ListOfTables();

                foreach (var tableName in listOfTables)
                {
                    var type = Type.GetType($"{typeof(BaseModel).Namespace}.{tableName}");
                    var method =
                        //disables as that is method description, not invocation, else infinite waiting
                        GetSyncAllTablesMethod();


                    var genericMethod = method.MakeGenericMethod(type);

                    await genericMethod.InvokeVoidAsync(this, null);
                }
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                    syncErrors = exc.PushResult.Errors;
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                try
                {
                    foreach (var error in syncErrors)
                    {
                        try
                        {
                            if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                                await error.CancelAndUpdateItemAsync(error.Result);
                            else
                                await error.CancelAndDiscardItemAsync();

                            Debug.WriteLine(
                                $@"Error executing sync operation. Item: {error.TableName} ({
                                        error.Item["id"]
                                    }). Operation discarded.");
                        }
                        catch (Exception e) 
                        {
                            Console.WriteLine(e);
                            InsightsLog.LogError(e, "SyncAllAsync_inside_syncErrors");
                        }
                       
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    InsightsLog.LogError(e, "SyncAllAsync_outside_syncErrors");
                }
               
            }
                
        }

        [SuppressMessage("Await.Warning", "CS4014:Await.Warning")]
        private static MethodInfo GetSyncAllTablesMethod()
        {
#pragma warning disable 4014
            //we extracting the method definitions by reflection, not executing the method itself
            return GenericsHelper.GetMethod<ItemManagerWrapper>(x => x.SyncTableAsync<BaseModel>());
#pragma warning restore 4014
        }


        private static List<string> ListOfTables()
        {
            var listOfTables = new List<string>
            {
               
                //SMS data we get from the inbox before parsing
                
                nameof(LogData),
                nameof(UserAccount)
               
            };

           
            return listOfTables;
        }
    }
}