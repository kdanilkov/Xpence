using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpenceShared.Contracts;
using XpenceShared.Models;

namespace XpenceShared.Repositories
{
    public class LogDataRepository:ILogDataRepository
    {
        private readonly IItemManagerWrapper _itemManagerWrapper;
        public LogDataRepository(IItemManagerWrapper itemManagerWrapper)
        {
            _itemManagerWrapper = itemManagerWrapper;
        }
        public async Task<IEnumerable<LogData>> GetLogDataIEnumerableAsync(Expression<Func<LogData, bool>> predicate = null, bool sync = false)
        {
            return await _itemManagerWrapper.GetEnumeratorAsync(predicate, sync);
        }

        public async Task<LogData> GetLogDataAsync(string id, bool sync = false)
        {
            var result = await _itemManagerWrapper.GetLookupAsync<LogData>(id, sync);
            return result;
        }

        public async Task CreateLogDataAsync(LogData logData, bool sync = false)
        {
            await _itemManagerWrapper.SaveTaskAsync(logData, sync);
        }


        public async Task UpdateLogDataAsync(LogData logData, bool sync = false)
        {
            await _itemManagerWrapper.SaveTaskAsync(logData, sync);
        }

        public async Task UpsertLogDataBatchAsync(List<LogData> logData, bool sync = false)
        {
            await _itemManagerWrapper.UpsertBatch(logData, sync);
        }
    }
}