using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpenceShared.Models;

namespace XpenceShared.Contracts
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccount>> GetUserAccountIEnumerableAsync(Expression<Func<UserAccount, bool>> predicate = null, bool sync = false);
        Task<UserAccount> GetUserAccountAsync(string id, bool sync = false);
        Task CreateUserAccountAsync(UserAccount userAccount, bool sync = false);
        Task UpdateUserAccountAsync(UserAccount userAccount, bool sync = false);
        Task UpsertUserAccountBatchAsync(List<UserAccount> userAccount, bool sync = false);
    }
}