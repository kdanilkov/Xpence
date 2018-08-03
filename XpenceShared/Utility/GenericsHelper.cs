using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace XpenceShared.Utility
{
    public static class GenericsHelper
    {
        public static MethodInfo GetMethod<T>(Expression<Action<T>> expr)
        {
            return  ((MethodCallExpression)expr.Body)
                .Method
                .GetGenericMethodDefinition();
            
        }

       
            public static async Task<object> InvokeAsync(this MethodInfo @this, object obj, params object[] parameters)
            {
                dynamic awaitable = @this.Invoke(obj, parameters);
                await awaitable;
                return awaitable.GetAwaiter().GetResult();
            }

      

        public static async Task InvokeVoidAsync(this MethodInfo @this, object obj, params object[] parameters)
        {
            var task = (Task)@this.Invoke(obj, parameters);
            await task.ConfigureAwait(false);
            
        }

    }
}