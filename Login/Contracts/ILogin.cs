using System.Threading.Tasks;

//using Microsoft.WindowsAzure.MobileServices;

namespace Login.Contracts
{
    public interface ILogin
    {
        Task<bool> LoginUserAsync(string provider);
        Task<bool> LogoutAsync();
    }
}