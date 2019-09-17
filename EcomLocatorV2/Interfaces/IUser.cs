using EcomLocatorV2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcomLocatorV2.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers() ;
    }
}
