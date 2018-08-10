using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XpenceShared.Contracts;
using XpenceShared.Models;

namespace XpenceShared.Repositories
{
    public class UserAccountRepository: IUserAccountRepository
    {
        private readonly IItemManagerWrapper _itemManagerWrapper;

        public UserAccountRepository(IItemManagerWrapper itemManagerWrapper)
        {
            _itemManagerWrapper = itemManagerWrapper;
        }

        public async Task<IEnumerable<UserAccount>> GetUserAccountIEnumerableAsync(Expression<Func<UserAccount, bool>> predicate = null, bool sync = false)
        {
            return await _itemManagerWrapper.GetEnumeratorAsync(predicate, sync);
        }

        public async Task<UserAccount> GetUserAccountAsync(string id, bool sync = false)
        {
            var result = await _itemManagerWrapper.GetLookupAsync<UserAccount>(id, sync);
            return result;
        }

        public async Task CreateUserAccountAsync(UserAccount userAccount, bool sync = false)
        {
            await _itemManagerWrapper.SaveTaskAsync(userAccount, sync);
        }

        public async Task UpdateUserAccountAsync(UserAccount userAccount, bool sync = false)
        {
            await _itemManagerWrapper.SaveTaskAsync(userAccount, sync);
        }

        public async Task UpsertUserAccountBatchAsync(List<UserAccount> userAccount, bool sync = false)
        {
            await _itemManagerWrapper.UpsertBatch(userAccount, sync);
        }
    }
}