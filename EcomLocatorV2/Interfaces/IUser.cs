using EcomLocatorV2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcomLocatorV2.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers() ;
    }
}
