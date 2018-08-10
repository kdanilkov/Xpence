using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpenceShared.Models;

namespace XpenceShared.Contracts
{
    public interface IItemManagerWrapper
    {
       
        Task<ObservableCollection<T>> GetObservableCollectinAsync<T>(Expression<Func<T, bool>> predicate, bool syncItems = false) where T : BaseModel;
        Task<IEnumerable<T>>GetEnumeratorAsync<T>(Expression<Func<T, bool>> predicate=null, bool syncItems = false) where T : BaseModel;
        Task<int> GetCountAsync<T>(Expression<Func<T, bool>> predicate, bool syncItems = false) where T : BaseModel;
        Task <T> GetLookupAsync<T>(string id, bool syncItems = false) where T : BaseModel;
        Task SaveTaskAsync<T>(T item, bool syncItems = false) where T : BaseModel;
        Task UpsertBatch<T>(IList<T> items, bool syncItems = false) where T : BaseModel;
        Task DeleteTaskAsync<T>(T item, bool syncItems = false) where T : BaseModel;
        Task SyncSingleTableAsync<T>() where T : BaseModel;
        Task SyncAllAsync();
    }
}