using EcomLocatorV2.Model;
using System.Threading.Tasks;

namespace EcomLocatorV2.Interfaces
{
    public interface IUserDetailsService
    {
        Task<UserDetails> GetUserDetails(int UserId);
    }
}
