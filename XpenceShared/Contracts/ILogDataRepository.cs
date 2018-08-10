using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpenceShared.Models;


namespace XpenceShared.Contracts
{
    public interface ILogDataRepository
    {
        Task<IEnumerable<LogData>> GetLogDataIEnumerableAsync(Expression<Func<LogData, bool>> predicate = null, bool sync = false);
        Task<LogData> GetLogDataAsync(string id, bool sync = false);
        Task CreateLogDataAsync(LogData logData, bool sync = false);
        Task UpdateLogDataAsync(LogData logData, bool sync = false);
        Task UpsertLogDataBatchAsync(List<LogData> logData, bool sync = false);
    }
}